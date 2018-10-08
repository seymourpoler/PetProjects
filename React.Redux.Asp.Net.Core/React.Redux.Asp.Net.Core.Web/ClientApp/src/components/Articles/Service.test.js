import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';

describe('Service', () => {
    let service;

    beforeEach(() => {
        service = new Service();
    });

    describe('when finding articles is requested', () => {

        it('returns internal server error if there is internal server error', async () => {
            window.fetch = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.InternalServerError
            }));

            const result = await service.find();

            expect(result.type).toBe(HttpStatusCode.InternalServerError);
        });

        it('returns bad request if there errors', async () => {
            const errors = [{ fieldId: 'title', errorCode: 'Required' }, { fieldId: 'subTitle', errorCode: 'Required' }];
            window.fetch = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.BadRequest,
                json: () => new Promise((resolve, reject) => {
                    resolve(errors);
                })
            }));

            const result = await service.find();

            expect(result.type).toBe(HttpStatusCode.BadRequest);
            expect(result.errors).toBe(errors);
        });

        it('returns articles', async () => {
            const articles = [{ id: 1, title: 'title-one' }, { id: 2, title: 'title-two' }];
            window.fetch = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.Ok,
                json: () => new Promise((resolve, reject) => {
                    resolve(articles);
                })
            }));

            const result = await service.find();

            expect(result.type).toBe(HttpStatusCode.Ok);
            expect(result.articles).toBe(articles);
        });
    });

    describe('when deleting article is requested', async () => {
        const id = 'article-id';
        it('returns internal server error if there is internal server error', async () => {
            window.fetch = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.InternalServerError
            }));

            const result = await service.delete(id);

            expect(result.type).toBe(HttpStatusCode.InternalServerError);
        });

        it('returns bad request if there errors', async () => {
            const errors = [{ fieldId: 'title', errorCode: 'Required' }, { fieldId: 'subTitle', errorCode: 'Required' }];
            window.fetch = jest.fn().mockImplementation(() =>({
                status: HttpStatusCode.BadRequest,
                json: () => new Promise((resolve, reject) => {
                    resolve(errors);
                })
            }));

            const result = await service.delete(id);

            expect(result.type).toBe(HttpStatusCode.BadRequest);
            expect(result.errors).toBe(errors);
        });

        it('returns articles', async () => {
            const articles = [{ id: 1, title: 'title-one' }, { id: 2, title: 'title-two' }];
            window.fetch = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.Ok,
                json: () => new Promise((resolve, reject) => {
                    resolve(articles);
                })
            }));

            const result = await service.delete(id);

            expect(result.type).toBe(HttpStatusCode.Ok);
            expect(result.articles).toBe(articles);
        });
    });

    describe('when adding article is requested', () => {
        const article = { title: 'title' };
        it('returns internal server error if there is internal server error', async () => {
            window.fetch = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.InternalServerError
            }));

            const result = await service.add(article);

            expect(result.type).toBe(HttpStatusCode.InternalServerError);
        });
    });
});