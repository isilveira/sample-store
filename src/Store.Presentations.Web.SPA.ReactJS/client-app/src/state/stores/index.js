import { createBrowserHistory } from 'history'
import { applyMiddleware, compose, createStore } from 'redux'
import thunk from 'redux-thunk';
import { routerMiddleware } from 'connected-react-router'

import { Reducers } from '../reducers';

export const history = createBrowserHistory();

const configureStore = (preloadedStore) => {
    const store = createStore(
        Reducers(history),
        preloadedStore,
        compose(
            applyMiddleware(thunk),
            applyMiddleware(routerMiddleware(history))
        )
    );

    return store;
}

export default configureStore;