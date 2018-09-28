import { SHOW_SPINNER } from './Actions.types';
import Service from './Service';


export const showSpinner = () => {
    return {
        type: SHOW_SPINNER
    };
};

export const findArticles = () => {
    let articles = Service.find();
    return {
        type: LIST_ARTICLES,
        payload: id
    };
};