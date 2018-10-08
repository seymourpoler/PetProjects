﻿import HttpStatusCode from '../../HttpStatusCode';

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

    async add(article) {
        const response = await fetch(this.url, {
            method: 'POST',
            body: JSON.stringify(article),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (response.status === HttpStatusCode.InternalServerError) {
            return { type: HttpStatusCode.InternalServerError };
        }
        throw 'not implemented';
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