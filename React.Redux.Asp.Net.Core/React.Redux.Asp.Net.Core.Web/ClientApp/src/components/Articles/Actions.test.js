import { SHOW_SPINNER, HIDE_SPINNER } from './Actions.types';
import { showSpinner, hideSpinner, findArticles } from './Actions';
import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';
import { INTERNAL_SERVER_ERROR, BAD_REQUEST, OK } from '../../HttpStatusCode.types';

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
        it('shows error message if there is an internal server error', async () => {
            Service.find = () => {
                return { statusCode: HttpStatusCode.InternalServerError };
            };

            let result = await findArticles();

            expect(result.type).toBe(INTERNAL_SERVER_ERROR);
        });

        it('shows error messages if there is errors', async () => {
            Service.find = () => {
                return { statusCode: HttpStatusCode.BadRequest, errors: [{fieldId: 'titles', errorCode: 'Required'}] };
            };

            let result = await findArticles();

            expect(result.type).toBe(BAD_REQUEST);
            expect(result.errors).not.toBeNull();
        });

        it('shows articles', async () => {
            Service.find = () => {
                return { statusCode: HttpStatusCode.Ok, articles: [{ id:1, title: 'title-article', description: 'description-article' }] };
            };

            let result = await findArticles();

            expect(result.type).toBe(OK);
            expect(result.articles).not.toBeNull();
        });
    });

    describe('when deleting article is requested', () => {
    });
});