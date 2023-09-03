import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { push } from 'connected-react-router';

import { Paper, Grid } from '@mui/material';

import { styled } from '@mui/material/styles';

import Templates from '../templates';
import { PageHeader } from './';

const StyledPaper = styled(Paper)(({theme}) => ({
    ...theme.typography.body2,
    minWidth:'300px',
    width: '100%',
    marginBottom: theme.spacing(2)
}));

const StyledGrid = styled(Grid)(({theme}) => ({
    ...theme.typography.body2,
    display: 'flex',
    flexWrap: 'wrap'
}));

const Page = (props) => {
    const isToShowThePageHeader = props.title || props.returnUrl;
    const title = props.title;
    const returnUrl = props.returnUrl;
    return (
        <Templates.MaterialTemplate.DashboardLayout>
            <StyledPaper>
                {
                    isToShowThePageHeader ? (<PageHeader title={title} returnUrl={returnUrl} />) : null
                }
                <StyledGrid container spacing={0}>
                    {props.children}
                </StyledGrid>
            </StyledPaper>
        </Templates.MaterialTemplate.DashboardLayout>
    );
};

const mapStateToProps = store => ({});

const mapDispatchToProps = dispatch => bindActionCreators({ push }, dispatch);

const connectedComponent = connect(mapStateToProps, mapDispatchToProps)(Page);

export default connectedComponent;