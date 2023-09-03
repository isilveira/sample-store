import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { ApplicationActionType } from '../../../state/actions';

import AppThemeProvider from './AppThemeProvider';
import PersistentDrawerLeft from './PersistentDrawerLeft';

import {
    Snackbar,
    Dialog, DialogTitle, DialogContent, DialogContentText, DialogActions,
    Button, Slide, 
    useMediaQuery
} from '@mui/material';
import MuiAlert from '@mui/material/Alert';
import { useTheme } from '@mui/material/styles';

const Transition = React.forwardRef(function Transition(props, ref) {
    return <Slide direction="up" ref={ref} {...props} />;
});
const DashboardSnackBar = (props) => {
    return (
        <Snackbar open={props.open} autoHideDuration={props.duration} onClose={props.onClose} TransitionComponent={Transition}>
            <MuiAlert elevation={6} variant="filled" onClose={props.onClose} severity={props.severity}>
                {props.message}
            </MuiAlert>
        </Snackbar>
    );
};
const DashboardLayout = (props) => {
    const { application } = props;
    const { snackBar } = application;
    const { dialog } = application;
    const theme = useTheme();
    const fullScreen = useMediaQuery(theme.breakpoints.down('md'));
    return (
        <AppThemeProvider>
            <PersistentDrawerLeft>
                {props.children}
            </PersistentDrawerLeft>

            <Dialog
                fullScreen={fullScreen}
                open={dialog.open}
                onClose={dialog.close}
                TransitionComponent={Transition}
                aria-labelledby="responsive-dialog-title"
                >
                <DialogTitle id="responsive-dialog-title">{dialog.title}</DialogTitle>
                <DialogContent>
                    <DialogContentText>{ dialog.message }</DialogContentText>
                </DialogContent>
                <DialogActions>
                    {dialog.actions.map((action, index) => <Button key={index} variant={action.variant} onClick={() => { action.onClick(); }} color={action.color}>{action.text}</Button>)}
                </DialogActions>
            </Dialog>

            <DashboardSnackBar open={snackBar.open} duration={2500} severity={snackBar.severity} message={snackBar.message} onClose={() => { props.ApplicationNotificatioClose(); }} />
        </AppThemeProvider>
    );
};

const {
    ApplicationNotificatioClose
} = ApplicationActionType.actions;

const mapStateToProps = store => ({
    application: store.ApplicationState.application,
    pathname: store.router.location.pathname,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        ApplicationNotificatioClose,
    }, dispatch);

export default connect(mapStateToProps, mapDispatchToProps)(DashboardLayout);
