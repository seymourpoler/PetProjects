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

export const findArticles = async () => {
    let service = new Service();
    const result = await service.find();
    if (result.statusCode === HttpStatusCode.InternalServerError) {
        return { type: INTERNAL_SERVER_ERROR, articles: [], errors: [] };
    }
    if (result.statusCode === HttpStatusCode.BadRequest) {
        return { type: BAD_REQUEST, articles: [], errors: result.errors };
    }

    return { type: OK, articles: result.articles, errors: [] };
};