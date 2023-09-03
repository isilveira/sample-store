import React from 'react';
import { connect } from 'react-redux';
import { ThemeProvider, createTheme } from '@mui/material/styles';

const appTheme = createTheme({
    typography: {
        useNextVariants: true
    },
})

const AppThemeProvider = (props) => {
    return (
        <ThemeProvider theme={appTheme}>
            {props.children}
        </ThemeProvider>
    );
}

const mapStateToProps = store => ({
    application: store.ApplicationState.application
});

export default connect(mapStateToProps)(AppThemeProvider);
