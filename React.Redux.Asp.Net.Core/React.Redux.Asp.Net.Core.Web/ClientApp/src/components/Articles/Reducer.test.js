import ActionTypes from './Actions.types';
import reducer from './Reducer';

describe('Reducer', () => {
    it('initializes state if is undefined', () => {
        const result = reducer(undefined, {});

        expect(result.articles).not.toBeNull();
        expect(result.type).toBe(ActionTypes.ShowArticles);
    });

    it('returns state for showing spinner', () => {
        const result = reducer({}, { type: ActionTypes.ShowSpinner });

        expect(result.showSpinner).toBeTruthy();
    });

    it('returns state for hidding spinner', () => {
        const result = reducer({}, { type: ActionTypes.HideSpinner });

        expect(result.showSpinner).toBeFalsy();
    });

    it('returns state for internal server error', () => {
        const result = reducer({}, { type: ActionTypes.ShowErrors });

        expect(result.showSpinner).toBeFalsy();
        expect(result.type).toBe(ActionTypes.ShowErrors);
    });

    it('returns state for bad request', () => {
        const result = reducer({}, { type: ActionTypes.ShowErrors, errors: [{ fieldId: 'title', errorCode: 'Required' }, { fieldId: 'subTitle', errorCode: 'Required' }] });

        expect(result.ShowSpinner).toBeFalsy();
        expect(result.type).toBe(ActionTypes.ShowErrors);
        expect(result.errors).not.toBeNull();
    });

    it('returns state for showing articles', () => {
        const result = reducer({}, { type: ActionTypes.ShowArticles, articles: [{ id: 1, title: 'title-article', description: 'description-article' }] });

        expect(result.showSpinner).toBeFalsy();
        expect(result.type).toBe(ActionTypes.ShowArticles);
        expect(result.articles).not.toBeNull();
    });
});