import { SignInManagerActionType } from '../../actions';
const INITIAL_STATE = {
    manager: null,
    loggedUser: null
};

const ChangeManager = (state, payload) => {
    return { ...state, manager: payload.manager };
};

const SetLoggedUser = (state, payload) => {
    return { ...state, loggedUser: payload.loggedUser };
};

export const SignInManagerReducer = (state = INITIAL_STATE, action) => {
    console.log("---- REDUCER: SignInManagerReducer")
    console.log(action);
    switch (action.type) {
        case SignInManagerActionType.types.CREATE_MANAGER: return ChangeManager(state, action.payload);
        case SignInManagerActionType.types.SET_LOGGED_USER: return SetLoggedUser(state, action.payload);
        default: return state;
    }
};