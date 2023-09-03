import PageIndex, { routes as RouteIndex } from './PageIndex';
import PageNotFound, { routes as RouteNotFound } from './PageNotFound';
import PageUnauthorizedAccess, { routes as RouteUnauthorizedAccess } from './PageUnauthorizedAccess';

const index = {
    routes: [
        ...RouteIndex,
        ...RouteNotFound,
        ...RouteUnauthorizedAccess
    ],
    pages: {
        Index: PageIndex,
        NotFound: PageNotFound,
        UnauthorizedAccess: PageUnauthorizedAccess
    }
};

export default index;