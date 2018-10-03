import { SHOW_SPINNER, HIDE_SPINNER } from './Actions.types';
import { Action } from './Actions';
import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';
import { INTERNAL_SERVER_ERROR, BAD_REQUEST, OK } from '../../HttpStatusCode.types';

describe('Articles', () => {
    describe('when showing spinner is requested', () => {
        it('shows spinner', () => {
            let action = new Action(null);

            const result = action.showSpinner();

            expect(result.type).toBe(SHOW_SPINNER);
        });
    });

    describe('when hidding spinner is requested', () => {
        it('hides spinner', () => {
            let action = new Action(null);

            const result = action.hideSpinner();

            expect(result.type).toBe(HIDE_SPINNER);
        });
    });

    describe('when finding articles is requested', () => {
        let service;

        beforeEach(() => {
            service = new Service();
        });

        it('shows error message if there is an internal server error', async () => {
            service.find = async function() {
                return { statusCode: HttpStatusCode.InternalServerError };
            };
            let action = new Action(service);

            let result = await action.findArticles();

            expect(result.type).toBe(INTERNAL_SERVER_ERROR);
        });

        it('shows error messages if there is errors', async () => {
            service.find = async function () {
                return { statusCode: HttpStatusCode.BadRequest, errors: [{ fieldId: 'titles', errorCode: 'Required' }] };
            };
            let action = new Action(service);

            let result = await action.findArticles();

            expect(result.type).toBe(BAD_REQUEST);
            expect(result.errors).not.toBeNull();
        });

        it('shows articles', async () => {
            service.find = async function () {
                return { statusCode: HttpStatusCode.Ok, articles: [{ id: 1, title: 'title-article', description: 'description-article' }] };
            };
            let action = new Action(service);

            let result = await action.findArticles();

            expect(result.type).toBe(OK);
            expect(result.articles).not.toBeNull();
        });
    });

    xdescribe('when deleting article is requested', () => {
    });
});