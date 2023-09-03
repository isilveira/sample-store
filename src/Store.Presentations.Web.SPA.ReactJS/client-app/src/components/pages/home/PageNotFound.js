import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { push } from 'connected-react-router';

import { Page } from '../../molecules';

const PageNotFound = (props) => {
    return (
        <Page title="Not found">
            The page you tried to access was not found.
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

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(PageNotFound);

export const routes = [
    { access: () => true, name: "NOTFOUND", path: "/notfound", params: [], component: connectedComponent }
];

export default connectedComponent;