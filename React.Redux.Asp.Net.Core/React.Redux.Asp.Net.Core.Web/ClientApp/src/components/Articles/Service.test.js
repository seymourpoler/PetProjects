import Service from './Service';
import { INTERNAL_SERVER_ERROR } from '../../HttpStatusCode.types';

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
});