import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { push } from 'connected-react-router';

import ApiConnectedTable from './ApiConnectedTable';

import { ApplicationDialogShow, ApplicationDialogClose, ApplicationDialogAddAction } from '../../state/actions/application/actions';
import { CreateApiService } from '../../state/actions/apiModelWrapper/actions';
import { CheckAccess } from '../../state/actions/signInManager/actions';
import { ServerUrl } from '../atoms/ServerUrlHelper';

const COLLECTION = "samples";
const AccessFunctionAdd = (dispatch, state) => CheckAccess(COLLECTION, "CREATE", null, true, false, null)(dispatch, state);
const AccessFunctionEdit = (dispatch, state) => CheckAccess(COLLECTION, "EDIT", null, true, false, null)(dispatch, state);
const AccessFunctionDelete = (dispatch, state) => CheckAccess(COLLECTION, "DELETE", null, true, false, null)(dispatch, state);

const TableComponent = (props) => {
    const { parentComponentId } = props;
    const COMPONENT_ID = `${parentComponentId}-${COLLECTION}-table`;
    const api = props.CreateApiService(`${COMPONENT_ID}-service`, ServerUrl(`api/${COLLECTION}`));
    const config = {
        elevation: props.elevation||1,
        title: 'List of samples',
        configId: COMPONENT_ID,
        endPoint: ServerUrl(`api/${COLLECTION}`),
        id: 'id',
        dense: false,
        defaultPageSize: 5,
        columns: [{
            id: 'description',
            disablePadding: false,
            label: 'Description'
        }],
        actions: {
            'add': { access: AccessFunctionAdd, handler: () => { addHandler(); } },
            'edit': { access: AccessFunctionEdit, handler: (id) => { editHandler(id); } },
            'delete': { access: AccessFunctionDelete, handler: (ids, callback) => { deleteHandler(ids, callback); } },
            //'filter': { component: null }
        }
    };
    const deleteHandler = (ids, callback) => {
        let actions = [];
        console.log(props.ApplicationDialogAddAction);
        actions.push(props.ApplicationDialogAddAction('Cancel', 'outlined', 'error', () => { props.ApplicationDialogClose(); }));
        actions.push(props.ApplicationDialogAddAction('Delete', 'contained', 'error', () => { ids.map(id => api.Delete(id)); props.ApplicationDialogClose(); callback(); }));

        props.ApplicationDialogShow('Confirm', 'Do you want to confirm the delete action?', actions);
    };
    const addHandler = () => {
        props.push(`/${COLLECTION}/create`);
    };
    const editHandler = (id) => {
        props.push(`/${COLLECTION}/${id}`);
    };
    return (<ApiConnectedTable config={config} />);
};

const mapStateToProps = store => ({
    application: store.ApplicationState.application
});

const mapDispatchToProps = dispatch => bindActionCreators({
    push,
    CreateApiService,
    ApplicationDialogShow,
    ApplicationDialogClose,
    ApplicationDialogAddAction
}, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(TableComponent);

export default connectedComponent;