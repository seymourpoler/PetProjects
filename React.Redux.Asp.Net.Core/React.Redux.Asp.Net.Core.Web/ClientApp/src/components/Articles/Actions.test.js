import ActionTypes from './Actions.types';
import { Actions } from './Actions';
import Service from './Service';
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
        it('dispatchs showig spinner', () => {
            actions.showSpinner();

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
        });
    });

    describe('when hidding spinner is requested', () => {
        it('dispatchs hidding spinner', () => {
            actions.hideSpinner();

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
        });
    });

    describe('when finding articles is requested', () => {
        it('dispatchs showing error messages if there are errors', async () => {
            const errors = [{ fieldId: 'titles', errorCode: 'Required' }];
            service.find = async function () {
                expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
                return { isOK: false, errors: errors };
            };

            await actions.findArticles();

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowErrors, articles:[], errors: errors });
        });

        it('dispatchs showing articles', async () => {
            const articles = [{ id: 1, title: 'title-article', description: 'description-article' }];
            service.find = async function () {
                expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
                return { isOk: true, articles: articles };
            };

            await actions.findArticles();

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowArticles, articles: articles, errors: [] });
        });
    });

    describe('when deleting article is requested', () => {
        it('dispatchs showing errors if there are errors', async () => {
            const articleId = 'article-id';
            const errors = [{ fieldId: Errors.General, errorCode: Errors.NotFound }];
            service.delete = async function (id) {
                expect(id).toBe(articleId);
                expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
                return { isOk: false, errors: errors };
            };

            await actions.deleteArticle(articleId);

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowErrors, errors: errors });
        });

        it('dispatchs new list of articles', async () => {
            const articleId = 'article-id';
            const articles = [{ id: 1, title: 'title-article', description: 'description-article' }];
            service.delete = async function (id) {
                expect(id).toBe(articleId);
                expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
                return { isOk: true, articles: articles};
            };

            await actions.deleteArticle(articleId);

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowArticles, articles: articles, errors: [] });
        });
    });

    describe('when adding new article is requested', () => {
        const title = 'article-title';
        it('dispatchs showing errors if there are errors', async () => {
            const errors = [{ fieldId: Errors.General, errorCode: Errors.NotFound }];
            service.add = async function (article) {
                expect(article.title).toBe(title);
                expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
                return { isOK: true, errors: errors };
            };

            await actions.addArticle({title});

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowErrors, errors: errors });
        });

        it('dispatchs new list of articles', async () => {
            const articles = [{ id: 1, title: 'title-article', description: 'description-article' }];
            service.add = async function (article) {
                expect(article.title).toBe(title);
                expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowSpinner });
                return { isOk: true, articles: articles };
            };

            await actions.addArticle({title});

            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.HideSpinner });
            expect(dispatcher.dispatch).toHaveBeenCalledWith({ type: ActionTypes.ShowArticles, articles: articles, errors: [] });
        });
    });
});