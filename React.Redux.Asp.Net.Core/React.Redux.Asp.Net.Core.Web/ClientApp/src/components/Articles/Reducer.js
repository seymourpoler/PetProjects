import { SHOW_SPINNER, HIDE_SPINNER, INTERNAL_SERVER_ERROR, BAD_REQUEST, SHOW_ARTICLES } from './Actions.types';
import HttpStatusCode from '../../HttpStatusCode';

const initialState = { statusCode: HttpStatusCode.Ok, articles: [] };

export default function reducer(state, action) {
    state = state || initialState;
    switch (action.type) {
        case SHOW_SPINNER:
        case HIDE_SPINNER:
        case INTERNAL_SERVER_ERROR:
            throw 'not implemented';
        
        default:
            return state;
    }
}