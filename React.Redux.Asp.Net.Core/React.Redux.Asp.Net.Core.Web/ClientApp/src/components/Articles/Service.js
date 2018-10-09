import HttpStatusCode from '../../HttpStatusCode';
import Errors from '../../Errors.type';

export default class Service {
    constructor() {
        this.url = '/api/articles/';
    }

    //TODO: remove duplication
    async find() {
        const response = await fetch(this.url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (response.status === HttpStatusCode.InternalServerError) {
            return { isOk: false, errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (response.status === HttpStatusCode.BadRequest) {
            var errors = await response.json();
            return {
                isOk: false,
                errors: errors
            };
        }
        if (response.status === HttpStatusCode.Ok) {
            var articles = await response.json();
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
        const response = await fetch(this.url, {
            method: 'POST',
            body: JSON.stringify(article),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (response.status === HttpStatusCode.InternalServerError) {
            return { isOk: false, errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (response.status === HttpStatusCode.BadRequest) {
            var errors = await response.json();
            return {
                isOk: false,
                errors: errors
            };
        }
        if (response.status === HttpStatusCode.Ok) {
            var articles = await response.json();
            return {
                isOk: true,
                articles: articles
            };
        }
        console.log('adding articles response: ', response);
        return { type: '' };
    }

    //TODO: remove duplication
    async delete (id) {
        const response = await fetch(this.url + id, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (response.status === HttpStatusCode.InternalServerError) {
            return { isOk: false, errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (response.status === HttpStatusCode.BadRequest) {
            var errors = await response.json();
            return { isOk: false,  errors: errors };
        }
        if (response.status === HttpStatusCode.Ok) {
            var articles = await response.json();
            return {
                isOk: true,
                articles: articles
            };
        }
        console.log('find articles response: ', response);
        return { type: '' };
    }
}