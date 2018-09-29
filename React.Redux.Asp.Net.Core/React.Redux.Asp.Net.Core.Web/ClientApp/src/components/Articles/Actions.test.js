import { SHOW_SPINNER, HIDE_SPINNER, INTERNAL_SERVER_ERROR, BAD_REQUEST } from './Actions.types';
import { showSpinner, hideSpinner, findArticles } from './Actions';
import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';

describe('Articles', () => {
    it('shows spinner', () => {
        let result = showSpinner();

        expect(result.type).toBe(SHOW_SPINNER);
    });

    it('hides spinner', () => {
        let result = hideSpinner();

        expect(result.type).toBe(HIDE_SPINNER);
    });

    describe('when finding articles is requested', () => {
        it('shows error message if there is an internal server error', () => {
            Service.find = () => {
                return { statusCode: HttpStatusCode.InternalServerError };
            };

            let result = findArticles();

            expect(result.type).toBe(INTERNAL_SERVER_ERROR);
        });

        it('shows error messages if there is errors', () => {
            Service.find = () => {
                return { statusCode: HttpStatusCode.BadRequest, errors: [{fieldId: 'titles', errorCode: 'Required'}] };
            };

            let result = findArticles();

            expect(result.type).toBe(BAD_REQUEST);
        });
    });
});