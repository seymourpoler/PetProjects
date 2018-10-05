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
            return { type: ActionTypes.ShowErrors, articles: [], errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (result.statusCode === HttpStatusCode.BadRequest) {
            return { type: ActionTypes.ShowErrors, articles: [], errors: result.errors };
        }

        return { type: ActionTypes.ShowArticles, articles: result.articles, errors: [] };
    }

    async deleteArticle(id) {
        const result = await this.service.delete(id);
        if (result.statusCode === HttpStatusCode.InternalServerError) {
            return { type: ActionTypes.ShowErrors, articles: [], errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (result.statusCode === HttpStatusCode.BadRequest) {
            return { type: SHOW_ERRORS, articles: [], errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        return { type: ActionTypes.ShowArticles };
    }
}

export const Factory = (dispatcher) => {
    return new Actions(dispatcher, new Service());
};
