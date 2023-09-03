import { push } from 'connected-react-router';

import { ApplicationNotificatioAdd } from '../application/actions';
import { SignManagerStart } from '../signInManager/actions';

import { SHA256 } from 'crypto-js';
import jwt_decode from 'jwt-decode';

import {
    CREATE_API_SERVICE, CREATE_API_FILTER,
    REQUEST_GETBYFILTER, RECEIVE_GETBYFILTER,
    REQUEST_GETBYID, RECEIVE_GETBYID,
    REQUEST_DELETE, RECEIVE_DELETE,
    REQUEST_PATCH, RECEIVE_PATCH,
    REQUEST_POST, RECEIVE_POST,
    REQUEST_PUT, RECEIVE_PUT,
    EXPIRE_COLLECTION,

    EXPIRE_ENTITY,

    RECEIVE_PATCH_VALIDATIONS,
    RECEIVE_POST_VALIDATIONS,
    RECEIVE_PUT_VALIDATIONS
} from './types';

const getUrl = (collection, filterProperties, searchProperties, ordenation, pagination, responseProperties) => {
    let endpoint = '';

    if (collection && collection !== '') {
        endpoint += collection;
    }

    let queryStringArray = [];

    if (filterProperties && Array.isArray(filterProperties) && filterProperties.length > 0) {
        queryStringArray.push(filterProperties.map(filterProperty => `${filterProperty.name}=${filterProperty.value}`).join('&'));
    }

    if (searchProperties) {
        let searchPropertiesArray = [];
        if (searchProperties.query && searchProperties.query !== '') {
            searchPropertiesArray.push(`query=${searchProperties.query}`);
        }
        if (searchProperties.strict) {
            searchPropertiesArray.push(`strict=${searchProperties.strict ? 'true' : 'false'}`);
        }
        if (searchProperties.phrase) {
            searchPropertiesArray.push(`phrase=${searchProperties.phrase ? 'true' : 'false'}`);
        }

        if (searchPropertiesArray.length > 0) {
            queryStringArray.push(searchPropertiesArray.join('&'));
        }
    }

    if (ordenation) {
        let ordenationArray = [];
        if (ordenation.orderBy && ordenation.orderBy !== '') {
            ordenationArray.push(`orderby=${ordenation.orderBy}`);
        }
        if (ordenation.order && ordenation.order !== '') {
            ordenationArray.push(`order=${ordenation.order}`);
        }

        if (ordenationArray.length > 0) {
            queryStringArray.push(ordenationArray.join('&'));
        }
    }

    if (pagination) {
        let paginationArray = [];
        if (pagination.number && pagination.number > 0) {
            paginationArray.push(`pagenumber=${pagination.number}`);
        }
        if (pagination.size && pagination.size > 0) {
            paginationArray.push(`pagesize=${pagination.size}`);
        }

        if (paginationArray.length > 0) {
            queryStringArray.push(paginationArray.join('&'));
        }
    }

    if (responseProperties && Array.isArray(responseProperties) && responseProperties.length > 0) {
        queryStringArray.push(responseProperties.map(responseProperty => `responseProperties=${responseProperty}`).join('&'));
    }

    if (queryStringArray && queryStringArray.length > 0) {
        endpoint += '?' + queryStringArray.join('&');
    }

    return endpoint;
};

const getRequest = (endPoint, method, data, dispatch, getState) => {
    const { SignInManagerState } = getState();
    const { loggedUser } = SignInManagerState;

    let headers = new Headers();
    console.log(`>> M-GetRequest (loggedUser has value: ${loggedUser ? true : false} / loggedUser.id_token: ${loggedUser?.id_token ? true : false})`);
    if (loggedUser && loggedUser.id_token) {
        console.log(`!! GetRequest Headers - ${loggedUser.id_token}`);

        var decodedToken = jwt_decode(loggedUser.id_token);
        console.log(decodedToken);

        if (decodedToken.exp * 1000 <= Date.now()) {
            console.log("Token expirou!");
            dispatch(SignManagerStart());
            return;
        }

        headers.append('Authorization', `Bearer ${loggedUser.id_token}`);
    }

    let config = {
        method: method,
        headers: headers,
        mode: 'cors',
        cache: 'default',
    };

    if (data) {
        config.body = data;
    }

    return new Request(endPoint, config);
};
const convertReponseToJson = (dispatch, response) => {
    if (response.ok) {
        return response.json();
    } else {
        let message = `The server responded unexpectedly. ResponseCode: ${response.status}. ${response.statusText}`;
        console.error(message);
        dispatch(ApplicationNotificatioAdd('error', message, true));
    }
};
const ApiWrapper = (id, collection, expires) => (dispatch) => {
    return {
        id: id,
        collection: collection,
        expires: expires,
        GetByFilter(filter) {
            let queryEndPoint = getUrl(
                this.collection,
                filter.filterProperties,
                filter.searchProperties,
                filter.ordenation,
                filter.pagination,
                filter.responseProperties
            );

            dispatch(HttpGet(this.collection, queryEndPoint, this.expires));

            return queryEndPoint;
        },
        GetById(id) {
            let queryEndPoint = `${this.collection}/${id}`;

            dispatch(HttpGetByID(this.collection, queryEndPoint, this.expires));

            return queryEndPoint;
        },
        Delete(id, returnUrl) {
            let commandEndPoint = `${this.collection}/${id}`;

            dispatch(HttpDelete(this.collection, commandEndPoint, this.expires, returnUrl));

            return commandEndPoint;
        },
        Patch(id, patchModel, returnUrl) {
            let commandEndPoint = `${this.collection}/${id}`;

            dispatch(HttpPatch(this.collection, commandEndPoint, patchModel, this.expires, returnUrl));

            return commandEndPoint;
        },
        Post(postModel, returnUrl) {
            let commandEndPoint = `${this.collection}`;

            dispatch(HttpPost(this.collection, commandEndPoint, postModel, this.expires, returnUrl));

            return commandEndPoint;
        },
        Put(id, putModel, returnUrl) {
            let commandEndPoint = `${this.collection}/${id}`;

            dispatch(HttpPut(this.collection, commandEndPoint, putModel, this.expires, returnUrl));

            return commandEndPoint;
        }
    }
};

const ApiFilter = (id) => {
    return {
        id: id,
        filterProperties: [],
        searchProperties: {},
        ordenation: {},
        pagination: {},
        responseProperties: [],
        clear() {
            this.filterProperties = [];
            this.searchProperties = {};
            this.ordenation = {};
            this.pagination = {};
            this.responseProperties = [];

            return this;
        },
        addFilter(propertyName, propertyValue) {
            this.filterProperties.push({ 'name': propertyName, 'value': propertyValue });

            return this;
        },
        setSearch(query, strict, phrase) {
            this.searchProperties = { 'query': query, 'strict': strict, 'phrase': phrase };

            return this;
        },
        setOrdenation(orderBy, order) {
            this.ordenation = { 'orderBy': orderBy, 'order': order };

            return this;
        },
        setPagination(size, number) {
            this.pagination = { 'size': size, 'number': number };

            return this;
        },
        addResponseProperties(propertyNames) {
            propertyNames.map(property => this.responseProperties.push(property));

            return this;
        },
        addResponseProperty(propertyName) {
            this.responseProperties.push(propertyName);

            return this;
        }
    }
};

const CreateApiService = (id, collection) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { apiServices } = ApiModelWrapperState;

    let filteredApiServices = apiServices.filter((apiService) => apiService.id === id);

    let apiServiceExists = filteredApiServices && filteredApiServices.length === 1;

    if (!apiServiceExists) {
        let minutesToExpire = 5 * 60 * 1000;
        let service = ApiWrapper(id, collection, minutesToExpire)(dispatch);
        dispatch({
            type: CREATE_API_SERVICE,
            payload: service
        });

        return service;
    } else {
        return filteredApiServices[0];
    }
};

const CreateApiFilter = (id) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { apiFilters } = ApiModelWrapperState;

    let filteredApiFilters = apiFilters.filter((apiFilter) => apiFilter.id === id);

    let apiFiltersExists = filteredApiFilters && filteredApiFilters.length === 1;

    if (!apiFiltersExists) {
        let filter = ApiFilter(id);
        dispatch({
            type: CREATE_API_FILTER,
            payload: filter
        });

        return filter;
    } else {
        return filteredApiFilters[0];
    }
};

const HttpGet = (_collection, _endPoint, _expires) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { queries } = ApiModelWrapperState;
    const { collections } = queries;

    let collection = collections[_endPoint];
    let timeStamp = Date.now();
    if (collection && collection.timeStamp > timeStamp && collection.endPoint === _endPoint) {
        console.log(`**** HttpGet - ${_endPoint} - Collection found - No need to request backend.`);
        return;
    }

    let request = getRequest(_endPoint, 'GET', null, dispatch, getState);
    if (request) {
        fetch(request)
            .then(response => convertReponseToJson(dispatch, response))
            .then(data => {
                let timeStamp = Date.now();
                timeStamp += _expires;
                let receiveAction = { type: RECEIVE_GETBYFILTER, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp, response: data } };
                console.log('** RECEIVE ACTION - HttpGet');
                console.log(receiveAction);
                dispatch(receiveAction);
            })
            .catch((error) => {
                console.error(error);
                dispatch(ApplicationNotificatioAdd('error', error, true));
            });

        timeStamp += _expires;
        dispatch({ type: REQUEST_GETBYFILTER, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp, response: null } });
    }
};
const HttpGetByID = (_collection, _endPoint, _expires) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { queries } = ApiModelWrapperState;
    const { entities } = queries;

    let entity = entities[_endPoint];
    let timeStamp = Date.now();
    if (entity && entity.timeStamp > timeStamp && entity.endPoint === _endPoint) {
        console.log(`**** HttpGetByID - ${_endPoint} - Entity found - No need to request backend.`);
        return;
    }

    let request = getRequest(_endPoint, 'GET', null, dispatch, getState);
    if (request) {
        fetch(request)
            .then(response => convertReponseToJson(dispatch, response))
            .then(data => {
                let timeStamp = Date.now();
                timeStamp += _expires;
                let receiveAction = { type: RECEIVE_GETBYID, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp, response: data } };
                console.log('** RECEIVE ACTION - HttpGetByID');
                console.log(receiveAction);
                dispatch(receiveAction);
            })
            .catch((error) => {
                console.error(error);
                dispatch(ApplicationNotificatioAdd('error', error, true));
            });

        timeStamp += _expires;
        dispatch({ type: REQUEST_GETBYID, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp, response: null } });
    }
};
const HttpDelete = (_collection, _endPoint, _expires, _returnUrl) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { commands } = ApiModelWrapperState;
    const { deletes } = commands;

    let deleteCommand = deletes[_endPoint];
    let timeStamp = Date.now();

    let request = getRequest(_endPoint, 'DELETE', null, dispatch, getState);

    if (request) {
        fetch(request)
            .then(response => convertReponseToJson(dispatch, response))
            .then(data => {
                console.log(data);
                if (data.statusCode === 200) {
                    let timeStamp = Date.now();
                    dispatch(ApplicationNotificatioAdd('success', data.message, true));
                    dispatch({ type: EXPIRE_COLLECTION, payload: { collection: _collection, timeStamp: timeStamp } });
                    dispatch({ type: EXPIRE_ENTITY, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp } });
                    dispatch({ type: RECEIVE_DELETE, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp } });
                    if (_returnUrl) {
                        dispatch(push(_returnUrl));
                    }
                } else {
                    dispatch(ApplicationNotificatioAdd('error', data.message, true));
                }
            })
            .catch((error) => {
                console.error(error);
                dispatch(ApplicationNotificatioAdd('error', error, true));
            });

        if (deleteCommand && deleteCommand.endPoint === _endPoint && deleteCommand.timeStamp > timeStamp) {
            return;
        }

        timeStamp += _expires;
        dispatch({ type: REQUEST_DELETE, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp } });
    }
};
const HttpPatch = (_collection, _endPoint, _patchedModel, _expires, _returnUrl) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { commands } = ApiModelWrapperState;
    const { patchs } = commands;

    let patchCommand = patchs[_endPoint];
    let timeStamp = Date.now();
    let patchedData = JSON.stringify(_patchedModel);
    let hashToken = SHA256(patchedData).toString();

    let request = getRequest(_endPoint, 'PATCH', patchedData, dispatch, getState);

    if (request) {
        fetch(request)
            .then(response => convertReponseToJson(dispatch, response))
            .then(data => {
                console.log(data);
                if (data.statusCode === 200) {
                    let timeStamp = Date.now();
                    dispatch(ApplicationNotificatioAdd('success', data.message, true));
                    dispatch({ type: EXPIRE_COLLECTION, payload: { collection: _collection, timeStamp: timeStamp } });
                    dispatch({ type: EXPIRE_ENTITY, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp } });
                    dispatch({ type: RECEIVE_PATCH, payload: { collection: _collection, endPoint: _endPoint, token: hashToken, data: null } });
                    dispatch(push(_returnUrl));
                } else {
                    console.log(`PATCH ERROR - StatusCode: ${data.statusCode}.`);
                    dispatch(ApplicationNotificatioAdd('error', data.message, true));
                    if (data.data && data.data.entityExceptions) {
                        console.log('TODO: set entity validations on redux context!!!');
                        dispatch({ type: RECEIVE_PATCH_VALIDATIONS, payload: { collection: _collection, endPoint: _endPoint, token: hashToken, entityValidations: data.data.entityExceptions } });
                    }
                    if (data.data && data.data.domainExceptions && data.data.domainExceptions.length > 0) {
                        data.data.domainExceptions.map((value, index) => dispatch(ApplicationNotificatioAdd('error', value, true)));
                    }
                }
            })
            .catch((error) => {
                console.error(error);
                dispatch(ApplicationNotificatioAdd('error', error, true));
            });

        if (patchCommand && patchCommand.endPoint === _endPoint && (patchCommand.token === hashToken || patchCommand.timeStamp > timeStamp)) {
            return;
        }

        timeStamp += _expires;
        dispatch({ type: REQUEST_PATCH, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp, data: _patchedModel } });
    }
};
const HttpPost = (_collection, _endPoint, _postedModel, _expires, _returnUrl) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { commands } = ApiModelWrapperState;
    const { posts } = commands;

    let postCommand = posts[_endPoint];
    let timeStamp = Date.now();
    let postedData = JSON.stringify(_postedModel);
    let hashToken = SHA256(postedData).toString();

    let request = getRequest(_endPoint, 'POST', postedData, dispatch, getState);

    if (request) {
        fetch(request)
            .then(response => convertReponseToJson(dispatch, response))
            .then(data => {
                console.log(data);
                if (data.statusCode === 200) {
                    let timeStamp = Date.now();
                    dispatch(ApplicationNotificatioAdd('success', data.message, true));
                    dispatch({ type: EXPIRE_COLLECTION, payload: { collection: _collection, timeStamp: timeStamp } });
                    dispatch({ type: RECEIVE_POST, payload: { collection: _collection, endPoint: _endPoint, token: hashToken, data: null } });
                    dispatch(push(_returnUrl));
                } else {
                    console.log(`POST ERROR - StatusCode: ${data.statusCode}.`);
                    dispatch(ApplicationNotificatioAdd('error', data.message, true));
                    if (data.data && data.data.entityExceptions) {
                        console.log('TODO: set entity validations on redux context!!!');
                        dispatch({ type: RECEIVE_POST_VALIDATIONS, payload: { collection: _collection, endPoint: _endPoint, token: hashToken, entityValidations: data.data.entityExceptions } });
                    }
                    if (data.data && data.data.domainExceptions && data.data.domainExceptions.length > 0) {
                        data.data.domainExceptions.map((value, index) => dispatch(ApplicationNotificatioAdd('error', value, true)));
                    }
                }
            })
            .catch((error) => {
                console.error(error);
                dispatch(ApplicationNotificatioAdd('error', error, true));
            });

        if (postCommand && postCommand.endPoint === _endPoint && (postCommand.token === hashToken || postCommand.timeStamp > timeStamp)) {
            return;
        }

        timeStamp += _expires;
        dispatch({ type: REQUEST_POST, payload: { collection: _collection, endPoint: _endPoint, token: hashToken, data: _postedModel } });
    }
};
const HttpPut = (_collection, _endPoint, _puttedModel, _expires, _returnUrl) => (dispatch, getState) => {
    const { ApiModelWrapperState } = getState();
    const { commands } = ApiModelWrapperState;
    const { puts } = commands;

    let putCommnand = puts[_endPoint];
    let timeStamp = Date.now();
    let puttedData = JSON.stringify(_puttedModel);
    let hashToken = SHA256(puttedData).toString();

    let request = getRequest(_endPoint, 'PUT', puttedData, dispatch, getState);

    if (request) {
        fetch(request)
            .then(response => convertReponseToJson(dispatch, response))
            .then(data => {
                console.log(data);
                if (data.statusCode === 200) {
                    let timeStamp = Date.now();
                    dispatch(ApplicationNotificatioAdd('success', data.message, true));
                    dispatch({ type: EXPIRE_COLLECTION, payload: { collection: _collection, timeStamp: timeStamp } });
                    dispatch({ type: EXPIRE_ENTITY, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp } });
                    dispatch({ type: RECEIVE_PUT, payload: { collection: _collection, endPoint: _endPoint, token: hashToken, data: null } });
                    dispatch(push(_returnUrl));
                } else {
                    console.log(`PUT ERROR - StatusCode: ${data.statusCode}.`);
                    dispatch(ApplicationNotificatioAdd('error', data.message, true));
                    if (data.data && data.data.entityExceptions) {
                        console.log('TODO: set entity validations on redux context!!!');
                        dispatch({ type: RECEIVE_PUT_VALIDATIONS, payload: { collection: _collection, endPoint: _endPoint, token: hashToken, entityValidations: data.data.entityExceptions } });
                    }
                    if (data.data && data.data.domainExceptions && data.data.domainExceptions.length > 0) {
                        data.data.domainExceptions.map((value, index) => dispatch(ApplicationNotificatioAdd('error', value, true)));
                    }
                }
            })
            .catch((error) => {
                console.error(error);
                dispatch(ApplicationNotificatioAdd('error', error, true));
            });

        if (putCommnand && putCommnand.endPoint === _endPoint && (putCommnand.token === hashToken || putCommnand.timeStamp > timeStamp)) {
            return;
        }

        timeStamp += _expires;
        dispatch({ type: REQUEST_PUT, payload: { collection: _collection, endPoint: _endPoint, timeStamp: timeStamp, token: hashToken, data: _puttedModel } });
    }
};

export {
    CreateApiService,
    CreateApiFilter
};