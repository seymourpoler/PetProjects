import { SHOW_SPINNER, HIDE_SPINNER, INTERNAL_SERVER_ERROR, BAD_REQUEST, SHOW_ARTICLES } from './Actions.types';
import HttpStatusCode from '../../HttpStatusCode';

const initialState = { statusCode: HttpStatusCode.Ok, articles: [] };

export default function reducer(state, action) {
    state = state || initialState;
    switch (action.type) {
        case SHOW_SPINNER:
            return {
                ...state,
                showSpinner: true
            };
        case HIDE_SPINNER:
            return {
                ...state,
                showSpinner: false
            };
        case INTERNAL_SERVER_ERROR:
            return {
                ...state,
                showSpinner: false,
                statusCode: INTERNAL_SERVER_ERROR
            };
        case BAD_REQUEST:
            return {
                ...state,
                statusCode: BAD_REQUEST,
                errors: action.errors
            };
        
        default:
            return state;
    }
}