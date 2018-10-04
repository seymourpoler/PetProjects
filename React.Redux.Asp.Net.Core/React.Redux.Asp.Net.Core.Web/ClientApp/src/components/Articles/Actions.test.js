import { SHOW_SPINNER, HIDE_SPINNER, SHOW_ERRORS, SHOW_ARTICLES } from './Actions.types';
import { Actions } from './Actions';
import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';
import Errors from '../../Errors.type';

describe('Articles', () => {
    let service;

    beforeEach(() => {
        service = new Service();
    });

    describe('when showing spinner is requested', () => {
        it('shows spinner', () => {
            let actions = new Actions(null);

            const result = actions.showSpinner();

            expect(result.type).toBe(SHOW_SPINNER);
        });
    });

    describe('when hidding spinner is requested', () => {
        it('hides spinner', () => {
            let actions = new Actions(null);

            const result = actions.hideSpinner();

            expect(result.type).toBe(HIDE_SPINNER);
        });
    });

    describe('when finding articles is requested', () => {
        it('returns error message if there is an internal server error', async () => {
            service.find = async function() {
                return { statusCode: HttpStatusCode.InternalServerError };
            };
            let actions = new Actions(service);

            let result = await actions.findArticles();

            expect(result.type).toBe(HttpStatusCode.InternalServerError);
        });

        it('returns error messages if there is errors', async () => {
            service.find = async function () {
                return { statusCode: HttpStatusCode.BadRequest, errors: [{ fieldId: 'titles', errorCode: 'Required' }] };
            };
            let actions = new Actions(service);

            let result = await actions.findArticles();

            expect(result.type).toBe(HttpStatusCode.BadRequest);
            expect(result.errors).not.toBeNull();
        });

        it('returns articles', async () => {
            service.find = async function () {
                return { statusCode: HttpStatusCode.Ok, articles: [{ id: 1, title: 'title-article', description: 'description-article' }] };
            };
            let actions = new Actions(service);

            let result = await actions.findArticles();

            expect(result.type).toBe(HttpStatusCode.Ok);
            expect(result.articles).not.toBeNull();
        });
    });

    describe('when deleting article is requested', () => {
        it('returns error if there is an internal server error', async () => {
            const articleId = 'article-id';
            const errors = [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }];
            service.delete = async function (id) {
                expect(id).toBe(articleId);
                return { statusCode: HttpStatusCode.InternalServerError };
            };
            let actions = new Actions(service);

            let result = await actions.deleteArticle(articleId);

            expect(result.type).toBe(SHOW_ERRORS);
            expect(result.errors[0].errorCode).toBe(errors[0].errorCode);
        });

        it('returns errors if there are errors', async () => {
            const articleId = 'article-id';
            service.delete = async function (id) {
                expect(id).toBe(articleId);
                return { statusCode: HttpStatusCode.BadRequest, errors: [{ fieldId: Errors.General, errorCode: Errors.NotFound }] };
            };
            let actions = new Actions(service);

            let result = await actions.deleteArticle(articleId);

            expect(result.type).toBe(SHOW_ERRORS);
            expect(result.errors).not.toBeNull();
        });

        it('deletes an article', async () => {
            const articleId = 'article-id';
            service.delete = async function (id) {
                expect(id).toBe(articleId);
                return { statusCode: HttpStatusCode.Ok };
            };
            let actions = new Actions(service);

            let result = await actions.deleteArticle(articleId);

            expect(result.type).toBe(SHOW_ARTICLES);
        });
    });
});