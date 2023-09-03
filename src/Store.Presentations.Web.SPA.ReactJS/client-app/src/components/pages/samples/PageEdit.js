import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { Page } from '../../molecules';
import { FormSample } from '../../organisms';

import { CheckAccess } from '../../../state/actions/signInManager/actions';

const COLLECTION = "samples";
const ACTION = "Edit";

const PageEdit = (props) => {
    const { id } = props.match.params;
    const COMPONENT_ID = `${COLLECTION}-${ACTION.toLowerCase()}`;
    const title = `${ACTION} sample`;
    const returnUrl = `/${COLLECTION}`;
    return (
        <Page title={title} returnUrl={returnUrl}>
            <FormSample parentComponentId={COMPONENT_ID} id={id} params={null} />
        </Page>
    );
};

const mapStateToProps = store => ({});

const mapDispatchToProps = dispatch => bindActionCreators({}, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(PageEdit);

const AccessFunction = (dispatch, state) => CheckAccess(COLLECTION, ACTION.toUpperCase(), null, true, false, null)(dispatch, state);

export const routes = [
    { access: AccessFunction, name: `${COLLECTION.toUpperCase()}_${ACTION.toUpperCase()}`, path: `/${COLLECTION}/:id`, params: ['id'], component: connectedComponent },
];

export default connectedComponent;
