import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { push } from 'connected-react-router';

import { Page } from '../../molecules';

const PageUnauhtorizedAccess = (props) => {
    return (
        <Page title="Unauthorized Access">
            You do not have permission to access this page.
        </Page>
    );
}

const mapStateToProps = store => ({
    application: store.ApplicationState.application
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        push,
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(PageUnauhtorizedAccess);

export const routes = [
    { access: () => true, name: "UNAUHTORIZEDACCESS", path: "/unauthorizedaccess", params: [], component: connectedComponent }
];

export default connectedComponent;