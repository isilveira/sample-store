import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { Page } from '../../molecules';
import { TableSamples } from '../../organisms';

import { CheckAccess } from '../../../state/actions/signInManager/actions';

const COLLECTION = "samples";
const ACTION = "INDEX";

const PageIndex = (props) => {
    const COMPONENT_ID = `${COLLECTION}-${ACTION.toLowerCase()}`;
    return (
        <Page>
            <TableSamples parentComponentId={COMPONENT_ID} elevation={0} />
        </Page>
    );
}

const mapStateToProps = store => ({});

const mapDispatchToProps = dispatch =>
    bindActionCreators({}, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(PageIndex);

const AccessFunction = (dispatch, state) => CheckAccess(COLLECTION, ACTION.toUpperCase(), null, true, false, null)(dispatch, state);

export const routes = [
    { access: AccessFunction, name: `${COLLECTION.toUpperCase()}`, path: `/${COLLECTION}`, params: [], component: connectedComponent },
    { access: AccessFunction, name: `${COLLECTION.toUpperCase()}_${ACTION.toUpperCase()}`, path: `/${COLLECTION}/${ACTION.toLowerCase()}`, params: [], component: connectedComponent }
];

export default connectedComponent;