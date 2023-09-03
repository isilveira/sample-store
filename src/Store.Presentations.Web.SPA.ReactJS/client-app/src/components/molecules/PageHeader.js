import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { push } from 'connected-react-router';

import { Toolbar, Typography, Tooltip, IconButton } from '@mui/material';

import {
    KeyboardBackspace
} from '@mui/icons-material';

import { styled } from '@mui/material/styles';

const StyledPageHeader = styled(Toolbar)(({theme})=>({
    paddingLeft: theme.spacing(2),
    paddingRight: theme.spacing(1),
}));

const StyledPageTitle = styled(Typography)(({theme})=>({
    flex: '1 1 100%',
}))

const PageHeader = (props) => {
    const title = props.title;
    const returnUrl = props.returnUrl;
    const handleClickBack = (event) => {
        props.push(returnUrl);
    };
    return (
        <StyledPageHeader>
            {
                returnUrl ?
                    (<Tooltip title="Voltar">
                        <IconButton aria-label="back" onClick={handleClickBack} size="large">
                            <KeyboardBackspace />
                        </IconButton>
                    </Tooltip>)
                    : null
            }
            {
                title ?
                    (<StyledPageTitle variant="h6" id="tableTitle" component="div">
                        {title}
                    </StyledPageTitle>)
                    : null
            }
        </StyledPageHeader>
    );
};

const mapStateToProps = store => ({});

const mapDispatchToProps = dispatch => bindActionCreators({ push }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(PageHeader);

export default connectedComponent;