import {
    CREATE_MANAGER, SET_LOGGED_USER
} from './types';

import {
    SignManagerStart, SignInRedirect, SignInRedirectCallBack, SignOutRedirect, SignOutRedirectCallBack, CheckAccess
} from './actions';

const types = {
    CREATE_MANAGER, SET_LOGGED_USER
};

const actions = {
    SignManagerStart, SignInRedirect, SignInRedirectCallBack, SignOutRedirect, SignOutRedirectCallBack, CheckAccess
};

export {
    types, actions
};