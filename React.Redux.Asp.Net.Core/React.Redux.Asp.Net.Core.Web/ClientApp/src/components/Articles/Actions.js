import ActionTypes from './Actions.types';
import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';
import Errors from '../../Errors.type';

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

        if (result.statusCode === HttpStatusCode.InternalServerError) {
            return this.dispatcher.dispatch({
                type: ActionTypes.ShowErrors,
                articles: [],
                errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }]
            });
        }

        if (result.statusCode === HttpStatusCode.BadRequest) {
            return this.dispatcher.dispatch({
                type: ActionTypes.ShowErrors,
                articles: [],
                errors: result.errors
            });
        }

        this.dispatcher.dispatch({
            type: ActionTypes.ShowArticles,
            articles: result.articles,
            errors: []
        });
        
    }

    async deleteArticle(id) {
        this.showSpinner();
        const result = await this.service.delete(id);
        this.hideSpinner();
        if (result.statusCode === HttpStatusCode.InternalServerError) {
            return this.dispatcher.dispatch({
                type: ActionTypes.ShowErrors,
                errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }]
            });
        }
        if (result.statusCode === HttpStatusCode.BadRequest) {
            return this.dispatcher.dispatch({
                type: ActionTypes.ShowErrors,
                errors: result.errors
            });
        }
        if (result.statusCode === HttpStatusCode.Ok) {
            return this.dispatcher.dispatch({
                type: ActionTypes.ShowArticles,
                articles: result.articles,
                errors: []
            });
        }
        console.log('unkown statusCode from deleteArticle with id: ' + id, result);
    }
}

export const Factory = (dispatch) => {
    return new Actions({ dispatch }, new Service());
};
