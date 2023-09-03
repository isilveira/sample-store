import React from 'react';
import { Redirect } from "react-router-dom";
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { ConnectedRouter } from 'connected-react-router';

import {
    Route,
    Switch,
} from "react-router-dom";

import ROUTES from '../routes';

const Router = (props) => {
    return (
        <ConnectedRouter history={props.history}>
            <Switch>
                {ROUTES.map((route, index) => {
                    let { dispatch, store } = props;
                    return (<Route
                        exact={true}
                        key={index}
                        name={route.name}
                        path={route.path}
                        params={route.params}
                        //component={route.component}
                        render={(props) => route.access(dispatch, store) ? (<route.component {...props} />) : (<Redirect to={{ pathname: "/unauthorizedaccess", state: { from: route.path } }} />)}
                    />)
                }
                )}
            </Switch>
        </ConnectedRouter>
    );
}


const mapStateToProps = store => ({ store });

const mapDispatchToProps = dispatch => bindActionCreators({ dispatch }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(Router);
export default connectedComponent;