import { SHOW_SPINNER, HIDE_SPINNER } from './Actions.types';
import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';
import { INTERNAL_SERVER_ERROR, BAD_REQUEST, OK } from '../../HttpStatusCode.types';

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

    return { type: OK, articles: result.articles };
};