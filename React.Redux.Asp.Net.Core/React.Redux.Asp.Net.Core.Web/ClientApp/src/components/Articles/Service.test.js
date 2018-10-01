import Service from './Service';
import { INTERNAL_SERVER_ERROR, BAD_REQUEST } from '../../HttpStatusCode.types';

describe('Service', () => {
    let service;

    beforeEach(() => {
        service = new Service();
    });

    it('returns internal server error if there is internal server error', async () => {
        window.fetch = jest.fn().mockImplementation(() => ({
            status: INTERNAL_SERVER_ERROR,
        }));

        const result = await service.find();

        expect(result.type).toBe(INTERNAL_SERVER_ERROR);
    });

    it('returns bad request if there errors', async () => {
        const errors = [{ fieldId: 'title', errorCode: 'Required' }, { fieldId: 'subTitle', errorCode: 'Required' }];
        window.fetch = jest.fn().mockImplementation(() => ({
            status: BAD_REQUEST,
            json: () => new Promise((resolve, reject) => {
                resolve(errors);
            })
        }));

        const result = await service.find();

        expect(result.type).toBe(BAD_REQUEST);
        expect(result.errors).toBe(errors);
    });
});