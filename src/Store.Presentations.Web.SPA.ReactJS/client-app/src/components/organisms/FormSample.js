import React, { useState, useEffect } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { push } from 'connected-react-router';

import { FormControl, TextField, Button, Grid } from '@mui/material';

import { styled } from '@mui/material/styles';

import {
    ApplicationDialogShow, ApplicationDialogClose, ApplicationDialogAddAction
} from '../../state/actions/application/actions';
import { CreateApiService } from '../../state/actions/apiModelWrapper/actions';
import { ServerUrl } from '../atoms/ServerUrlHelper';

const StyledRootGrid = styled(Grid)(({ theme }) => ({
    ...theme.typography.body2,
    display: 'flex',
    flexWrap: 'wrap',
}));

const StyledFormControl = styled(FormControl)(({ theme }) => ({
    ...theme.typography.body2,
    padding: theme.spacing(1)
}));

const COLLECTION = "samples";

const FormComponent = (props) => {
    const { parentComponentId, id, params } = props;
    const COMPONENT_ID = `${parentComponentId}-${COLLECTION}-form`;
    const endPoint = ServerUrl(`api/${COLLECTION}`);
    const returnUrl = `/${COLLECTION}`;
    const { entities, posts, puts } = props;
    const [requestUrl, setRequestUrl] = useState('');
    const [validations, setValidations] = useState([]);
    const [updatedEntity, setUpdatedEntity] = useState({ description: '' });
    const [dbEntity, setDbEntity] = useState(null);

    const api = props.CreateApiService(`${COMPONENT_ID}-${COLLECTION}-service`, endPoint);

    const handleChange = (prop) => (event) => {
        setUpdatedEntity({ ...updatedEntity, [prop]: event.target.value });
    };
    const handleClickSave = () => {
        setValidations(null);
        console.log({ updatedEntity });
        if (id) {
            api.Put(id, updatedEntity, returnUrl);
        } else {
            api.Post(updatedEntity, returnUrl);
        }
    };
    useEffect(() => {
        if (id) {
            setRequestUrl(api.GetById(id));
        }
    }, [api, id, params]);
    useEffect(() => {
        if (id && entities && entities[requestUrl] && entities[requestUrl].response && entities[requestUrl].response.data !== dbEntity) {
            setDbEntity(entities[requestUrl].response.data);
            setUpdatedEntity(entities[requestUrl].response.data);
        }
    }, [id, entities, requestUrl, dbEntity, setDbEntity, setUpdatedEntity]);
    useEffect(() => {
        if (posts && posts[requestUrl] && posts[requestUrl].entityValidations && posts[requestUrl].entityValidations) {
            setValidations(posts[requestUrl].entityValidations);
        }
    }, [posts, requestUrl]);
    useEffect(() => {
        if (puts && puts[requestUrl] && puts[requestUrl].entityValidations && puts[requestUrl].entityValidations) {
            setValidations(puts[requestUrl].entityValidations);
        }
    }, [puts, requestUrl]);
    return (
        <StyledRootGrid container spacing={0}>
            <Grid container spacing={0} >
                <Grid item xs={12}>
                    <StyledFormControl fullWidth >
                        <TextField
                            error={validations && validations.Description && validations.Description.length > 0}
                            helperText={validations && validations.Description ? validations.Description.join(' ') : ''}
                            key="description" id="description" label="Description" variant="outlined"
                            value={updatedEntity.description || ''} onChange={handleChange('description')} />
                    </StyledFormControl>
                </Grid>
            </Grid>

            <Grid container spacing={0} justifyContent="flex-end" >
                <Grid item lg={2} md={4} xs={6}>
                    <StyledFormControl fullWidth >
                        <Button variant="contained" color="primary" onClick={handleClickSave}>Save</Button>
                    </StyledFormControl>
                </Grid>
            </Grid>
        </StyledRootGrid>
    );
};

const mapStateToProps = store => ({
    application: store.ApplicationState.application,
    entities: store.ApiModelWrapperState.queries.entities,
    puts: store.ApiModelWrapperState.commands.puts
});

const mapDispatchToProps = dispatch => bindActionCreators({
    push,
    CreateApiService,
    ApplicationDialogShow,
    ApplicationDialogClose,
    ApplicationDialogAddAction
}, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(FormComponent);

export default connectedComponent;