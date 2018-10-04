import { SHOW_SPINNER, HIDE_SPINNER, SHOW_ERRORS, SHOW_ARTICLES } from './Actions.types';
import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';
import Errors from '../../Errors.type';

export class Actions {
    constructor(service) {
        this.service = service;
    }

    showSpinner() {
        return {
            type: SHOW_SPINNER
        };
    }

    hideSpinner() {
        return {
            type: HIDE_SPINNER
        };
    }

    async findArticles() {
        const result = await this.service.find();
        if (result.statusCode === HttpStatusCode.InternalServerError) {
            return { type: HttpStatusCode.InternalServerError, articles: [], errors: [] };
        }
        if (result.statusCode === HttpStatusCode.BadRequest) {
            return { type: HttpStatusCode.BadRequest, articles: [], errors: result.errors };
        }

        return { type: HttpStatusCode.Ok, articles: result.articles, errors: [] };
    }

    async deleteArticle(id) {
        const result = await this.service.delete(id);
        if (result.statusCode === HttpStatusCode.InternalServerError) {
            return { type: SHOW_ERRORS, articles: [], errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (result.statusCode === HttpStatusCode.BadRequest) {
            return { type: SHOW_ERRORS, articles: [], errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        return { type: SHOW_ARTICLES };
    }
}

export const Factory = () => {
    return new Actions(new Service());
};
