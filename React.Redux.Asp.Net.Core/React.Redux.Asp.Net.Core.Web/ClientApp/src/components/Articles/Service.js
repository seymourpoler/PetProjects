import HttpStatusCode from '../../HttpStatusCode';

export default class Service {
    constructor() {
        this.url = '/api/articles/';
    }
    
    async find() {
        const response = await fetch(this.url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (response.status === HttpStatusCode.InternalServerError) {
            return { type: HttpStatusCode.InternalServerError };
        }
        if (response.status === HttpStatusCode.BadRequest) {
            var errors = await response.json();
            return {
                type: HttpStatusCode.BadRequest,
                errors: errors
            };
        }
        if (response.status === HttpStatusCode.Ok) {
            var articles = await response.json();
            return {
                type: HttpStatusCode.Ok,
                articles: articles
            };
        }
        console.log('find articles response: ', response);
        return { type: '' };
    }

    save (article) {
        throw 'not implemented';
    }

    async delete (id) {
        const response = await fetch(this.url + id, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (response.status === HttpStatusCode.InternalServerError) {
            return { type: HttpStatusCode.InternalServerError };
        }
        if (response.status === HttpStatusCode.BadRequest) {
            var errors = await response.json();
            return {
                type: HttpStatusCode.BadRequest,
                errors: errors
            };
        }
        if (response.status === HttpStatusCode.Ok) {
            var articles = await response.json();
            return {
                type: HttpStatusCode.Ok,
                articles: articles
            };
        }
        console.log('find articles response: ', response);
        return { type: '' };
    }
}