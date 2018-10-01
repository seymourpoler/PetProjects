import { INTERNAL_SERVER_ERROR, BAD_REQUEST } from '../../HttpStatusCode.types';

export default class Service {
    async find () {
        const response = await fetch('/api/articles', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (response.status === INTERNAL_SERVER_ERROR) {
            return { type: INTERNAL_SERVER_ERROR };
        }
        if (response.status === BAD_REQUEST) {
            var errors = await response.json();
            return {
                type: BAD_REQUEST,
                errors: errors
            };
        }
        throw 'not implemented';
    }

    save (article) {
        throw 'not implemented';
    }

    delete (id) {
        throw 'not implemented';
    }
}