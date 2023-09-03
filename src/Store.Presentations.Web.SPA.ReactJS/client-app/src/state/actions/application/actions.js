import {
    APPLICATION_NAME_SET,
    APPLICATION_MENU_OPEN,
    APPLICATION_MENU_CLOSE,
    APPLICATION_NOTIFICATION_ADD,
    APPLICATION_NOTIFICATION_SHOW,
    APPLICATION_NOTIFICATION_CLOSE,
    APPLICATION_DIALOG_SHOW,
    APPLICATION_DIALOG_CLOSE,
    APPLICATION_DIALOG_ADD_ACTION
} from './types';

const ApplicationNameSet = (name) => ({
    type: APPLICATION_NAME_SET,
    payload: {
        applicationName: name
    }
});
const ApplicationMenuOpen = () => ({
    type: APPLICATION_MENU_OPEN,
    payload: {
        isOpen: true
    }
});
const ApplicationMenuClose = () => ({
    type: APPLICATION_MENU_CLOSE,
    payload: {
        isOpen: false
    }
});

const ApplicationNotificatioAdd = (severity, message, autoClose) => (dispatch, getState) => {
    const { ApplicationState } = getState();
    const { snackBar } = ApplicationState.application;

    let notification = { severity, message, autoClose };
    if (snackBar.notifications.length === 0 && !snackBar.open) {
        dispatch(ApplicationNotificatioShow(notification));
    } else {
        dispatch({ type: APPLICATION_NOTIFICATION_ADD, payload: { notification: notification } });
    }
};
const ApplicationNotificatioShow = (notification) => (dispatch, getState) => {
    dispatch({ type: APPLICATION_NOTIFICATION_SHOW, payload: { notification: notification } });
};
const ApplicationNotificatioClose = () => (dispatch, getState) => {
    const { ApplicationState } = getState();
    const { snackBar } = ApplicationState.application;
    dispatch({ type: APPLICATION_NOTIFICATION_CLOSE, payload: {} });
    if (snackBar && snackBar.notifications && snackBar.notifications.length > 0) {
        let notification = snackBar.notifications[0];
        setTimeout(() => { dispatch(ApplicationNotificatioShow(notification)); }, 500);
    }
};
const ApplicationDialogShow = (title, message, actions) => (dispatch, getState) => {
    dispatch({ type: APPLICATION_DIALOG_SHOW, payload: { title: title, message: message, actions: actions } });
};
const ApplicationDialogClose = () => (dispatch, getState) => {
    dispatch({ type: APPLICATION_DIALOG_CLOSE });
};
const ApplicationDialogAddAction = (text, variant, color, onClick) => (dispatch, getState) => {
    dispatch({ type: APPLICATION_DIALOG_ADD_ACTION, payload: { text: text, variant: variant, color: color, onClick: onClick } });
};
const ApplicationDialogAlert = (title, message) => (dispatch, getState) => {
    let actions = [];
    dispatch(ApplicationDialogAddAction('Ok', 'text', 'primary', () => { dispatch(ApplicationDialogClose()); }));

    dispatch(ApplicationDialogShow(title, message, actions));
};

export {
    ApplicationNameSet,
    ApplicationMenuOpen,
    ApplicationMenuClose,
    ApplicationNotificatioAdd,
    ApplicationNotificatioShow,
    ApplicationNotificatioClose,
    ApplicationDialogShow,
    ApplicationDialogClose,
    ApplicationDialogAddAction,
    ApplicationDialogAlert
};