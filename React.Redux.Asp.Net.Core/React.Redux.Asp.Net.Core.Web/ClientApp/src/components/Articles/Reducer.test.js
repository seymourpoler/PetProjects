import { SHOW_SPINNER, HIDE_SPINNER } from './Actions.types';
import reducer from './Reducer';
import HttpStatusCode from '../../HttpStatusCode';
import { INTERNAL_SERVER_ERROR, BAD_REQUEST, OK } from '../../HttpStatusCode.types';

describe('Reducer', () => {
    it('initializes state if is undefined', () => {
        const result = reducer(undefined, {});

        expect(result.articles).not.toBeNull();
        expect(result.statusCode).toBe(HttpStatusCode.Ok);
    });

    it('returns state for showing spinner', () => {
        const result = reducer({}, { type: SHOW_SPINNER });

        expect(result.showSpinner).toBeTruthy();
    });

    it('returns state for hidding spinner', () => {
        const result = reducer({}, { type: HIDE_SPINNER });

        expect(result.showSpinner).toBeFalsy();
    });

    it('returns state for internal server error', () => {
        const result = reducer({}, { type: INTERNAL_SERVER_ERROR });

        expect(result.showSpinner).toBeFalsy();
        expect(result.statusCode).toBe(INTERNAL_SERVER_ERROR );
    });

    it('returns state for bad request', () => {
        const result = reducer({}, { type: BAD_REQUEST, errors: [{ fieldId: 'title', errorCode: 'Required' }, { fieldId: 'subTitle', errorCode: 'Required' }] });

        expect(result.showSpinner).toBeFalsy();
        expect(result.statusCode).toBe(BAD_REQUEST);
        expect(result.errors).not.toBeNull();
    });

    it('returns state for showing articles', () => {
        const result = reducer({}, { type: OK, articles: [{ id: 1, title: 'title-article', description:'description-article' }] });

        expect(result.showSpinner).toBeFalsy();
        expect(result.statusCode).toBe(OK);
        expect(result.articles).not.toBeNull();
    });
});