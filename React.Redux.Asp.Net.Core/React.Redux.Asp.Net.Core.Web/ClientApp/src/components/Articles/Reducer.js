import { SHOW_SPINNER, HIDE_SPINNER } from './Actions.types';
import HttpStatusCode from '../../HttpStatusCode';
import { INTERNAL_SERVER_ERROR, BAD_REQUEST, OK } from '../../HttpStatusCode.types';

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
                statusCode: INTERNAL_SERVER_ERROR
            };
        case BAD_REQUEST:
            return {
                ...state,
                statusCode: BAD_REQUEST,
                errors: action.errors
            };
        case OK:
            return {
                ...state,
                statusCode: OK,
                articles: action.articles
            };
        default:
            return state;
    }
}