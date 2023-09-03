import React, { Fragment } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { push } from 'connected-react-router';

import { SignManagerStart } from './state/actions/signInManager/actions';

const AppContainer = (props) => {
    const { SignManagerStart } = props;

    SignManagerStart();

    return (<Fragment>{props.children}</Fragment>);
}

const mapStateToProps = store => ({});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        SignManagerStart,
        push
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(AppContainer);

export default connectedComponent;