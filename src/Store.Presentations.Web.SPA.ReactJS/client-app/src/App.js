import React from 'react';
import { Provider } from 'react-redux';
import configureStore, { history } from './state/stores';

import { Navigation } from './navigation';
import AppContainer from './AppContainer';

import './App.css';

const store = configureStore();

const App = (props) => {
    return (
        <Provider store={store}>
            <AppContainer>
                <Navigation.Router history={history} />
            </AppContainer>
        </Provider>
    );
}

export default App;