import ActionTypes from './Actions.types';
import HttpStatusCode from '../../HttpStatusCode';

const initialState = { type: ActionTypes.ShowArticles, articles: [] };

export default function reducer(state, action) {
    state = state || initialState;
    switch (action.type) {
        case ActionTypes.ShowSpinner:
            return {
                ...state,
                showSpinner: true
            };
        case ActionTypes.HideSpinner:
            return {
                ...state,
                showSpinner: false
            };
        case ActionTypes.ShowErrors:
            return {
                ...state,
                type: action.type,
                errors: action.errors
            };
        case ActionTypes.ShowArticles:
            return {
                ...state,
                type: action.type,
                articles: action.articles
            };

        default:
            return state;
    }
}