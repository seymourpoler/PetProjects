import reducer from './Reducer';
import HttpStatusCode from '../../HttpStatusCode';

describe('Reducer', () => {
    it('initializes state if is undefined', () => {
        const result = reducer(undefined, {});

        expect(result.articles).not.toBeNull();
        expect(result.statusCode).toBe(HttpStatusCode.Ok);
    });

    xit('returns state for showing spinner', () => {
        const result = reducer({});
        
    });
});