import HttpStatusCode from '../../HttpStatusCode';

export default class Service {
    async find() {
        const response = await fetch('/api/articles', {
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

    delete (id) {
        throw 'not implemented';
    }
}