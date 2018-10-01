import { INTERNAL_SERVER_ERROR } from '../../HttpStatusCode.types';

export default class Service {
    async find () {
        const response = await fetch('/api/articles', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        console.log(response)
        if (response.status === INTERNAL_SERVER_ERROR) {
            return { type: INTERNAL_SERVER_ERROR };
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