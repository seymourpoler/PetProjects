import { SHOW_SPINNER, HIDE_SPINNER } from './Actions.types';
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
        case HttpStatusCode.InternalServerError:
            return {
                ...state,
                statusCode: HttpStatusCode.InternalServerError
            };
        case HttpStatusCode.BadRequest:
            return {
                ...state,
                statusCode: HttpStatusCode.BadRequest,
                errors: action.errors
            };
        case HttpStatusCode.Ok:
            return {
                ...state,
                statusCode: HttpStatusCode.Ok,
                articles: action.articles
            };

        default:
            return state;
    }
}