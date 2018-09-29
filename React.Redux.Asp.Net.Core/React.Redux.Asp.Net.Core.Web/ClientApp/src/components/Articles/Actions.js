import { SHOW_SPINNER, HIDE_SPINNER, INTERNAL_SERVER_ERROR, BAD_REQUEST, SHOW_ARTICLES } from './Actions.types';
import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';

export const showSpinner = () => {
    return {
        type: SHOW_SPINNER
    };
};

export const hideSpinner = () => {
    return {
        type: HIDE_SPINNER
    };
};

export const findArticles = () => {
    const result = Service.find();
    if (result.statusCode === HttpStatusCode.InternalServerError) {
        return { type: INTERNAL_SERVER_ERROR };
    }
    if (result.statusCode === HttpStatusCode.BadRequest) {
        return { type: BAD_REQUEST, errors: result.errors };
    }

    return { type: SHOW_ARTICLES, articles: result.articles };
};