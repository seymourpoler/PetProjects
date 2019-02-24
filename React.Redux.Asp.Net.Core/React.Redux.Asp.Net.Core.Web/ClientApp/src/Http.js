export default class Http {

    headers = { 'Content-Type': 'application/json' };

    async get(url) {
        const response = await fetch(url, {
            method: 'GET',
            headers: this.headers
        });
        return response;
    }

    async post(url, data) {
        const response = await fetch(url, {
            method: 'POST',
            body: JSON.stringify(data),
            headers: this.headers
        });
        return response;
    }

    async delete(url) {
        const response = await fetch(url, {
            method: 'DELETE',
            headers: this.headers
        });
        return response;
    }
}