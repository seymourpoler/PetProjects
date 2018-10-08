import ActionTypes from './Actions.types';

const initialState = { showSpinner: false, type: ActionTypes.ShowArticles, articles: [], errors: [] };

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
                articles: action.articles,
                errors: action.errors
            };

        default:
            return state;
    }
}