import { SHOW_SPINNER, HIDE_SPINNER, INTERNAL_SERVER_ERROR } from './Actions.types';
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
    let result = Service.find();
    if (result.statusCode === HttpStatusCode.InternalServerError) {
        return { type: INTERNAL_SERVER_ERROR };
    }
    throw 'not implemented';
};