import HttpStatusCode from '../../HttpStatusCode';
import Errors from '../../Errors.type';

export default class Service {
    url = '/api/articles/';
    http;

    constructor(http) {
        this.http = http;
    }

    async find() {
        const response = await this.http.get(this.url);
        const result = await this.handleResponse(response);
        return result;
    }

    async add(article) {
        const response = await this.http.post(this.url, article);
        const result = await this.handleResponse(response);
        return result;
    }

    async delete(id) {
        const response = await this.http.delete(this.url + id);
        const result = await this.handleResponse(response);
        return result;
    }

    async handleResponse(response) {
        if (response.status === HttpStatusCode.InternalServerError) {
            return { isOk: false, errors: [{ fieldId: Errors.General, errorCode: Errors.InternalServerError }] };
        }
        if (response.status === HttpStatusCode.BadRequest) {
            const errors = await response.json();
            return { isOk: false, errors: errors };
        }
        if (response.status === HttpStatusCode.Ok) {
            const articles = await response.json();
            return {
                isOk: true,
                articles: articles
            };
        }
        console.log('unknown status response: ', response);
        return { isOk: false };
    }
}