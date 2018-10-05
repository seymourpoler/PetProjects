import ActionTypes from './Actions.types';
import { Actions } from './Actions';
import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';
import Errors from '../../Errors.type';

describe('Articles', () => {
    let service;
    let dispatcher;
    let actions;

    beforeEach(() => {
        service = new Service();
        dispatcher = {};
        dispatcher.dispatch = jest.fn();
        actions = new Actions(dispatcher, service); 
    });

    describe('when showing spinner is requested', () => {
        it('shows spinner', () => {
            actions.showSpinner();

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
        });
    });

    describe('when hidding spinner is requested', () => {
        it('hides spinner', () => {
            actions.hideSpinner();

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
        });
    });

    describe('when finding articles is requested', () => {
        it('returns error message if there is an internal server error', async () => {
            service.find = async function () {
                expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
                return { statusCode: HttpStatusCode.InternalServerError };
            };

            await actions.findArticles();

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowErrors, articles: [], errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] });
        });

        it('returns error messages if there is errors', async () => {
            const errors = [{ fieldId: 'titles', errorCode: 'Required' }];
            service.find = async function () {
                expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
                return { statusCode: HttpStatusCode.BadRequest, errors: errors };
            };

            await actions.findArticles();

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowErrors, articles:[], errors: errors });
        });

        it('returns articles', async () => {
            const articles = [{ id: 1, title: 'title-article', description: 'description-article' }];
            service.find = async function () {
                expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
                return { statusCode: HttpStatusCode.Ok, articles: articles };
            };

            await actions.findArticles();

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowArticles, articles: articles, errors:[] });
        });
    });

    xdescribe('when deleting article is requested', () => {
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