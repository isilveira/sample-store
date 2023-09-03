import { ApiModelWrapperActionType } from '../../actions';

const INITIAL_STATE = {
    apiFilters: [],
    apiServices: [],
    queries: {
        collections: {},
        entities: {}
    },
    commands: {
        deletes: {},
        patchs: {},
        posts: {},
        puts: {}
    }
};
const setQueryCollection = (state, payload) => {
    state.queries.collections[payload.endPoint] = payload;
    return {
        ...state,
        queries: {
            ...state.queries,
            collections: {
                ...state.queries.collections
            }
        }
    };
};
const setQueryEntity = (state, payload) => {
    state.queries.entities[payload.endPoint] = payload;
    return {
        ...state,
        queries: {
            ...state.queries,
            entities: {
                ...state.queries.entities
            }
        }
    };
};
const setCommandDelete = (state, payload) => {
    state.commands.deletes[payload.endPoint] = payload;
    return {
        ...state,
        commands: {
            ...state.commands,
            deletes: {
                ...state.commands.deletes
            }
        }
    };
};
const setCommandDeleteValidations = (state, payload) => {
    state.commands.deletes[payload.endPoint] = {
        ...state.commands.deletes[payload.endPoint],
        entityValidations: payload.entityValidations
    };
    return {
        ...state,
        commands: {
            ...state.commands,
            deletes: {
                ...state.commands.deletes
            }
        }
    };
};
const setCommandPatch = (state, payload) => {
    state.commands.patchs[payload.endPoint] = payload;
    return {
        ...state,
        commands: {
            ...state.commands,
            patchs: {
                ...state.commands.patchs
            }
        }
    };
};
const setCommandPatchValidations = (state, payload) => {
    state.commands.patchs[payload.endPoint] = {
        ...state.commands.patchs[payload.endPoint],
        entityValidations: payload.entityValidations
    };
    return {
        ...state,
        commands: {
            ...state.commands,
            patchs: {
                ...state.commands.patchs
            }
        }
    };
};
const setCommandPost = (state, payload) => {
    state.commands.posts[payload.endPoint] = payload;
    return {
        ...state,
        commands: {
            ...state.commands,
            posts: {
                ...state.commands.posts
            }
        }
    };
};
const setCommandPostValidations = (state, payload) => {
    state.commands.posts[payload.endPoint] = {
        ...state.commands.posts[payload.endPoint],
        entityValidations: payload.entityValidations
    };
    return {
        ...state,
        commands: {
            ...state.commands,
            posts: {
                ...state.commands.posts
            }
        }
    };
};
const setCommandPut = (state, payload) => {
    state.commands.puts[payload.endPoint] = payload;
    return {
        ...state,
        commands: {
            ...state.commands,
            puts: {
                ...state.commands.puts
            }
        }
    };
};
const setCommandPutValidations = (state, payload) => {
    state.commands.puts[payload.endPoint] = {
        ...state.commands.puts[payload.endPoint],
        entityValidations: payload.entityValidations
    };
    return {
        ...state,
        commands: {
            ...state.commands,
            puts: {
                ...state.commands.puts
            }
        }
    };
};
const expireCollection = (state, payload) => {
    Object.entries(state.queries.collections).map((value, index) => {
        if (value[1].collection === payload.collection) {
            value[1].timeStamp = payload.timeStamp;
        }
    });
    return {
        ...state
    }
};
const expireEntity = (state, payload) => {
    Object.entries(state.queries.entities).map((value, index) => {
        if (value[1].collection === payload.collection && value[1].endPoint === payload.endPoint) {
            value[1].timeStamp = payload.timeStamp;
        }
    });
    return {
        ...state
    }
};
export const ApiModelWrapperReducer = (state = INITIAL_STATE, action) => {
    console.log("---- REDUCER: ApiModelWrapperReducer")
    console.log(action);
    switch (action.type) {
        case ApiModelWrapperActionType.types.CREATE_API_SERVICE: return {
            ...state,
            apiServices: [
                ...state.apiServices.filter(apiService => apiService.id !== action.payload.id),
                action.payload
            ]
        };
        case ApiModelWrapperActionType.types.CREATE_API_FILTER: return {
            ...state,
            apiFilters: [
                ...state.apiFilters.filter(apiFilter => apiFilter.id !== action.payload.id),
                action.payload
            ]
        };
        case ApiModelWrapperActionType.types.REQUEST_GETBYFILTER: return setQueryCollection(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_GETBYFILTER: return setQueryCollection(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_GETBYID: return setQueryEntity(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_GETBYID: return setQueryEntity(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_DELETE: return setCommandDelete(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_DELETE: return setCommandDelete(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_DELETE_VALIDATIONS: return setCommandDeleteValidations(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_PATCH: return setCommandPatch(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_PATCH: return setCommandPatch(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_PATCH_VALIDATIONS: return setCommandPatchValidations(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_POST: return setCommandPost(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_POST: return setCommandPost(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_POST_VALIDATIONS: return setCommandPostValidations(state, action.payload);
        case ApiModelWrapperActionType.types.REQUEST_PUT: return setCommandPut(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_PUT: return setCommandPut(state, action.payload);
        case ApiModelWrapperActionType.types.RECEIVE_PUT_VALIDATIONS: return setCommandPutValidations(state, action.payload);
        case ApiModelWrapperActionType.types.EXPIRE_COLLECTION: return expireCollection(state, action.payload);
        case ApiModelWrapperActionType.types.EXPIRE_ENTITY: return expireEntity(state, action.payload);
        default: return state;
    }
}