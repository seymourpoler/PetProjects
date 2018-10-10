import Service from './Service';
import HttpStatusCode from '../../HttpStatusCode';
import Http from '../../http';

describe('Service', () => {
    let service;
    let http;
    beforeEach(() => {
        http = new Http();
        service = new Service(http);
    });

    describe('when finding articles is requested', () => {

        it('returns internal server error if there is internal server error', async () => {
            http.get = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.InternalServerError
            }));

            const result = await service.find();

            expect(result.isOk).toBeFalsy();
        });

        it('returns bad request if there errors', async () => {
            const errors = [{ fieldId: 'title', errorCode: 'Required' }, { fieldId: 'subTitle', errorCode: 'Required' }];
            http.get = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.BadRequest,
                json: () => new Promise((resolve, reject) => {
                    resolve(errors);
                })
            }));

            const result = await service.find();

            expect(result.isOk).toBeFalsy();
            expect(result.errors).toBe(errors);
        });

        it('returns articles', async () => {
            const articles = [{ id: 1, title: 'title-one' }, { id: 2, title: 'title-two' }];
            http.get = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.Ok,
                json: () => new Promise((resolve, reject) => {
                    resolve(articles);
                })
            }));

            const result = await service.find();

            expect(result.isOk).toBeTruthy();
            expect(result.articles).toBe(articles);
        });
    });

    describe('when deleting article is requested', async () => {
        const id = 'article-id';
        it('returns internal server error if there is internal server error', async () => {
            http.delete = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.InternalServerError
            }));

            const result = await service.delete(id);

            expect(result.isOk).toBeFalsy();
        });

        it('returns bad request if there errors', async () => {
            const errors = [{ fieldId: 'title', errorCode: 'Required' }, { fieldId: 'subTitle', errorCode: 'Required' }];
            http.delete = jest.fn().mockImplementation(() =>({
                status: HttpStatusCode.BadRequest,
                json: () => new Promise((resolve, reject) => {
                    resolve(errors);
                })
            }));

            const result = await service.delete(id);

            expect(result.isOk).toBeFalsy();
            expect(result.errors).toBe(errors);
        });

        it('returns articles', async () => {
            const articles = [{ id: 1, title: 'title-one' }, { id: 2, title: 'title-two' }];
            http.delete = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.Ok,
                json: () => new Promise((resolve, reject) => {
                    resolve(articles);
                })
            }));

            const result = await service.delete(id);

            expect(result.isOk).toBeTruthy();
            expect(result.articles).toBe(articles);
        });
    });

    describe('when adding article is requested', () => {
        const article = { title: 'title' };
        it('returns internal server error if there is internal server error', async () => {
            http.post = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.InternalServerError
            }));

            const result = await service.add(article);

            expect(result.isOk).toBeFalsy();
        });

        it('returns bad request if there errors', async () => {
            const errors = [{ fieldId: 'title', errorCode: 'Required' }, { fieldId: 'subTitle', errorCode: 'Required' }];
            http.post = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.BadRequest,
                json: () => new Promise((resolve, reject) => {
                    resolve(errors);
                })
            }));

            const result = await service.add(article);

            expect(result.isOk).toBeFalsy();
            expect(result.errors).toBe(errors);
        });

        it('returns articles', async () => {
            const articles = [{ id: 1, title: 'title-one' }, { id: 2, title: 'title-two' }];
            http.post = jest.fn().mockImplementation(() => ({
                status: HttpStatusCode.Ok,
                json: () => new Promise((resolve, reject) => {
                    resolve(articles);
                })
            }));

            const result = await service.add(article);

            expect(result.isOk).toBeTruthy();
            expect(result.articles).toBe(articles);
        });
    });
});