import { SHOW_SPINNER, HIDE_SPINNER, INTERNAL_SERVER_ERROR } from './Actions.types';
import Service from './Service';

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
    if (result.status === 500) {
        return { type: INTERNAL_SERVER_ERROR };
    }
    throw 'not implemented';
};