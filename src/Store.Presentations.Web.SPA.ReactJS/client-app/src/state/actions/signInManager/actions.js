import * as oidc from 'oidc-client';
import {
    CREATE_MANAGER, SET_LOGGED_USER
} from './types';
import jwt_decode from 'jwt-decode';

const GetManager = (dispatch, getState) => {
    const { SignInManagerState, router, ApplicationState } = getState();
    const { authentication } = ApplicationState.application;
    const { manager } = SignInManagerState;

    if (authentication.allowAnonymous) return;

    var _manager = null;

    if (manager) {
        _manager = manager;
    } else {
        _manager = new oidc.UserManager({
            authority: authentication.authority,
            client_id: authentication.client_id,
            redirect_uri: authentication.redirect_uri,
            response_type: authentication.response_type,
            scope: authentication.scope,
            post_logout_redirect_uri: authentication.post_logout_redirect_uri
        });

        dispatch({ type: CREATE_MANAGER, payload: { manager: _manager } });
    }

    if (_manager && router && router.location && router.location.hash && router.location.hash.indexOf("id_token")) {
        console.log("registra o id_token");

        _manager.signinRedirectCallback()
            .then(user => {
                console.log(user);
                dispatch({ type: SET_LOGGED_USER, payload: { loggedUser: user } });
            })
            .catch(error => {
                console.error(error);
            })
            .finally(() => {
                if (window.location.hash) {
                    window.history.replaceState("", document.title, window.location.pathname);
                }
            });
    }

    return _manager;
};

const SignManagerStart = () => (dispatch, getState) => {
    const { ApplicationState } = getState();
    const { authentication } = ApplicationState.application;
    var _manager = GetManager(dispatch, getState);

    console.log("## SignManagerStart");

    if (!_manager && authentication.allowAnonymous) return;

    _manager.getUser().then(user => {
        if (user) {
            var decodedToken = jwt_decode(user.id_token);
            console.log(decodedToken);

            if (decodedToken.exp * 1000 <= Date.now()) {
                console.log("Token expirou!");
                _manager.signinRedirect();
                return;
            }

            console.log("** SignManagerStart - User found");
            dispatch({ type: SET_LOGGED_USER, payload: { loggedUser: user } });
        }
        else if (!authentication.allowAnonymous) {
            console.log("** SignManagerStart - User not found");
            _manager.signinRedirect();
        }
    });
};

const SignInRedirect = () => (dispatch, getState) => {
    const { ApplicationState } = getState();
    const { authentication } = ApplicationState.application;
    var _manager = GetManager(dispatch, getState);

    if (!_manager && authentication.allowAnonymous) return;

    _manager.getUser().then(user => {
        if (user) {
            console.log("User logged in", user);
            dispatch({ type: SET_LOGGED_USER, payload: { loggedUser: user } });
        }
        else {
            console.log("User not logged in");
            _manager.signinRedirect();
        }
    });
};

const SignInRedirectCallBack = () => (dispatch, getState) => {
    const { ApplicationState } = getState();
    const { authentication } = ApplicationState.application;
    var _manager = GetManager(dispatch, getState);

    if (!_manager && authentication.allowAnonymous) return;

    _manager.signinRedirectCallback()
        .then(user => {
            console.log(user);
            dispatch({ type: SET_LOGGED_USER, payload: { loggedUser: user } });
        })
        .catch(error => {
            console.error(error);
        });
};

const SignOutRedirect = () => (dispatch, getState) => {
    const { ApplicationState } = getState();
    const { authentication } = ApplicationState.application;
    var _manager = GetManager(dispatch, getState);

    if (!_manager && authentication.allowAnonymous) return;

    _manager.signoutRedirect()
        .then(user => {
            console.log(user);
            dispatch({ type: SET_LOGGED_USER, payload: { loggedUser: user } });
        })
        .catch(error => {
            console.error(error);
        });
};

const SignOutRedirectCallBack = () => (dispatch, getState) => {
    const { ApplicationState } = getState();
    const { authentication } = ApplicationState.application;
    var _manager = GetManager(dispatch, getState);

    if (!_manager && authentication.allowAnonymous) return;

    _manager.signoutRedirectCallBack()
        .then(user => {
            console.log(user);
            dispatch({ type: SET_LOGGED_USER, payload: { loggedUser: user } });
        })
        .catch(error => {
            console.error(error);
        });
};

const CheckAccess = (aggregate, action, allowAnonymous, checkClaims, checkRoles, allowedRoles) => (dispatch, getState) => {
    const { authentication } = getState.ApplicationState.application;
    console.log({ aggregate, action, allowAnonymous, checkClaims, checkRoles, allowedRoles, dispatch, getState });
    let { loggedUser } = getState.SignInManagerState;
    console.log("#### CheckAccess");
    console.log({ aggregate, action, allowAnonymous, dispatch, getState });
    var response = false;
    if (authentication.allowAnonymous || allowAnonymous) {
        response = true;
    } else if (loggedUser) {
        if (checkClaims) {
            console.log(loggedUser);
            let claim = loggedUser.profile[`${authentication.claims}.${aggregate}`];
            console.log(claim);
            response = claim && claim.indexOf(action) >= 0;
        } else if (checkRoles) {
            response = allowedRoles.any(role => loggedUser.profile['role'] ? loggedUser.profile['role'].any(role) : false);
        } else {
            response = true;
        }
    }

    console.log({ checkAccess: response });

    return response;
}

export {
    SignManagerStart, SignInRedirect, SignInRedirectCallBack, SignOutRedirect, SignOutRedirectCallBack, CheckAccess
};