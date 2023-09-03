import PageIndex, { routes as RouteIndex } from './PageIndex';
import PageCreate, { routes as RouteCreate } from './PageCreate';
import PageEdit, { routes as RouteEdit } from './PageEdit';

const index = {
    routes: [
        ...RouteIndex,
        ...RouteCreate,
        ...RouteEdit
    ],
    pages: {
        Index: PageIndex,
        Create: PageCreate,
        Edit: PageEdit
    }
};

export default index;