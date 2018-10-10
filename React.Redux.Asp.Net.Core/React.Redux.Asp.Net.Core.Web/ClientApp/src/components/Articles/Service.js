import HttpStatusCode from '../../HttpStatusCode';
import Errors from '../../Errors.type';

export default class Service {
    url = '/api/articles/';
    http;

    constructor(http) {
        this.http = http;
    }

    //TODO: remove duplication
    async find() {
        const response = await this.http.get(this.url);
        if (response.status === HttpStatusCode.InternalServerError) {
            return { isOk: false, errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (response.status === HttpStatusCode.BadRequest) {
            const errors = await response.json();
            return {
                isOk: false,
                errors: errors
            };
        }
        if (response.status === HttpStatusCode.Ok) {
            const articles = await response.json();
            return {
                isOk: true,
                articles: articles
            };
        }
        console.log('find articles response: ', response);
        return { type: '' };
    }

    //TODO: remove duplication
    async add(article) {
        const response = await this.http.post(this.url, article);
        if (response.status === HttpStatusCode.InternalServerError) {
            return { isOk: false, errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (response.status === HttpStatusCode.BadRequest) {
            const errors = await response.json();
            return {
                isOk: false,
                errors: errors
            };
        }
        if (response.status === HttpStatusCode.Ok) {
            const articles = await response.json();
            return {
                isOk: true,
                articles: articles
            };
        }
        console.log('adding articles response: ', response);
        return { type: '' };
    }

    //TODO: remove duplication
    async delete(id) {
        const response = await this.http.delete(this.url + id);
        if (response.status === HttpStatusCode.InternalServerError) {
            return { isOk: false, errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (response.status === HttpStatusCode.BadRequest) {
            const errors = await response.json();
            return { isOk: false,  errors: errors };
        }
        if (response.status === HttpStatusCode.Ok) {
            const articles = await response.json();
            return {
                isOk: true,
                articles: articles
            };
        }
        console.log('find articles response: ', response);
        return { type: '' };
    }
}