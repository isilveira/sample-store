import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { push } from 'connected-react-router';

import { Button, FormControl, Grid, Divider } from '@mui/material';

import { styled } from '@mui/material/styles';

import { Page } from '../../molecules';

import { ApplicationNotificatioAdd, ApplicationDialogAlert, ApplicationDialogShow, ApplicationDialogClose, ApplicationDialogAddAction } from '../../../state/actions/application/actions';
import { CheckAccess } from '../../../state/actions/signInManager/actions';

const StyledFormControl = styled(FormControl)(({theme})=>({
    padding: theme.spacing(1),
}));

const COLLECTION = "home";
const ACTION = "INDEX";

const PageIndex = (props) => {
    const handleClickCallAlert = () => {
        console.log(" -- handleClickCallAlert");
        console.log(props.ApplicationNotificatioAdd);
        
        props.ApplicationDialogAlert('Alert', 'Something happened!');
    };
    const handleClickCallNotification = () => {
        console.log(" -- handleClickCallNotification");
        
        props.ApplicationNotificatioAdd('success', 'Something happened!', false);
    };
    const handleClickCallFunction1 = () => {
        console.log(" -- handleClickCallFunction1");
        
        let actions = [];
        console.log(props.ApplicationDialogAddAction);
        actions.push(props.ApplicationDialogAddAction('Cancel', 'outlined', 'error', () => { props.ApplicationDialogClose(); }));
        actions.push(props.ApplicationDialogAddAction('Delete', 'contained', 'error', () => { props.ApplicationDialogClose(); }));

        props.ApplicationDialogShow('Confirm', 'Do you want to confirm the delete action?', actions);
    };
    const handleGoToUrl = (url) => {
        props.push(url);
    };
    return (
        <Page title="Dashboard">
            <Grid container spacing={0} >
                <Grid item xs={2} sm={4}>
                    <StyledFormControl fullWidth>
                        <Button variant="outlined" color="success" onClick={handleClickCallNotification}>Call Notification</Button>
                    </StyledFormControl>
                </Grid>
                <Grid item xs={2} sm={4}>
                    <StyledFormControl fullWidth>
                        <Button variant="outlined" color="info" onClick={handleClickCallAlert}>Call Alert</Button>
                    </StyledFormControl>
                </Grid>
                <Grid item xs={2} sm={4}>
                    <StyledFormControl fullWidth>
                        <Button variant="outlined" color="error" onClick={handleClickCallFunction1}>Call Dialog</Button>
                    </StyledFormControl>
                </Grid>
            </Grid>
            <Divider />
            <Grid container spacing={0} >
                <Grid item xs={2} sm={4}>
                    <StyledFormControl fullWidth>
                        <Button variant="outlined" color="success" onClick={() => handleGoToUrl('/samples')} >Samples</Button>
                    </StyledFormControl>
                </Grid>
            </Grid>
        </Page>
    );
}

const mapStateToProps = store => ({
    application: store.ApplicationState.application,
    manager: store.SignInManagerState.manager,
    loggedUser: store.SignInManagerState.loggedUser,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        ApplicationNotificatioAdd, ApplicationDialogShow, ApplicationDialogClose, ApplicationDialogAddAction, ApplicationDialogAlert,
        push
    }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(PageIndex);

const AccessFunction = (dispatch, state) => CheckAccess(COLLECTION, ACTION.toUpperCase(), true, false, false, null)(dispatch, state);

export const routes = [
    { access: AccessFunction, name: "ROOT", path: "/", params: [], component: connectedComponent },
    { access: AccessFunction, name: `${COLLECTION.toUpperCase()}`, path: `/${COLLECTION}`, params: [], component: connectedComponent },
    { access: AccessFunction, name: `${COLLECTION.toUpperCase()}_${ACTION.toUpperCase()}`, path: `/${COLLECTION}/${ACTION.toLowerCase()}`, params: [], component: connectedComponent }
];

export default connectedComponent;
