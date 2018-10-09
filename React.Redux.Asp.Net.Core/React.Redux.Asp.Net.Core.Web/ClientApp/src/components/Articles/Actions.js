import ActionTypes from './Actions.types';
import Service from './Service';

export class Actions {

    constructor(dispatcher, service) {
        this.dispatcher = dispatcher;
        this.service = service;
    }

    showSpinner() {
        this.dispatcher.dispatch({ type: ActionTypes.ShowSpinner });
    }

    hideSpinner() {
        this.dispatcher.dispatch({ type: ActionTypes.HideSpinner });
    }

    async findArticles() {
        this.showSpinner();
        const result = await this.service.find();
        this.hideSpinner();

        if (result.isOk) {
            return this.dispatcher.dispatch({
                type: ActionTypes.ShowArticles,
                articles: result.articles,
                errors: []
            });
        }

        return this.dispatcher.dispatch({
            type: ActionTypes.ShowErrors,
            articles: [],
            errors: result.errors
        });
    }

    async deleteArticle(id) {
        this.showSpinner();
        const result = await this.service.delete(id);
        this.hideSpinner();

        if (result.isOk) {
            return this.dispatcher.dispatch({
                type: ActionTypes.ShowArticles,
                articles: result.articles,
                errors: []
            });
        }

        return this.dispatcher.dispatch({
            type: ActionTypes.ShowErrors,
            errors: result.errors
        });
    }

    async addArticle(article) {
        this.showSpinner();
        const result = await this.service.add(article);
        this.hideSpinner();
        
        if (result.isOk) {
            return this.dispatcher.dispatch({
                type: ActionTypes.ShowArticles,
                articles: result.articles,
                errors: []
            });
        }

        return this.dispatcher.dispatch({
            type: ActionTypes.ShowErrors,
            errors: result.errors
        });
    }
}

export const Factory = (dispatch) => {
    return new Actions({ dispatch }, new Service());
};
