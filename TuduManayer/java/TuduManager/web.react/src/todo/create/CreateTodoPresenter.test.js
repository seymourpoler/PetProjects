import { createCreateTodoView } from './CreateTodoView';
import { CreateTodoPresenter } from './CreateTodoPresenter';
import { CreateTodoService } from './CreateTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';
import { createHttp } from '../../Http';
import { spyAllMethodsOf } from '../../Testing';

describe('Create Todo Presenter', () => {
    let view, presenter, service, http;

    beforeEach(() => {
        view = createCreateTodoView();
        spyAllMethodsOf(view);
        http = createHttp();
        spyAllMethodsOf(http);
        service = new CreateTodoService(http);
        presenter = new CreateTodoPresenter(view, service);
    });

    describe('when save new todo is requested',() => {
        it('cleans messages', async () => {
            const newTodo = {title: 'title', description: 'description'};
            http.post = () => {
                return { statusCode: HttpStatusCode.internalServerError };
            };

            await presenter.save(newTodo);

            expect(view.cleanMessages).toHaveBeenCalled();
        });

        it('shows spinner', async () => {
            const newTodo = {title: 'title', description: 'description'};
            http.post = () => {
                return { statusCode: HttpStatusCode.internalServerError };
            };

            await presenter.save(newTodo);

            expect(view.showSpinner).toHaveBeenCalled();
        });

        it('shows error if there is an internal server error', async () => {
            const newTodo = {title: 'title', description: 'description'};
            http.post = () => {
                return { statusCode: HttpStatusCode.internalServerError };
            };

           await presenter.save(newTodo);

            expect(view.showInternalServerError).toHaveBeenCalled();
        });

        it('shows errors if there are errors', async () => {           
            const newTodo = {title: 'title', description: 'description'};
            const errors = [];
            http.post = () => {
                return {
                    statusCode: HttpStatusCode.badRequest,
                    body: errors
                }
            };

            await presenter.save(newTodo);

            expect(view.showErrors).toHaveBeenCalledWith(errors);
        });

        it('creates new todo', async () => {
            const newTodo = {title: 'title', description: 'description'};
            http.post = () => {
                return { statusCode: HttpStatusCode.ok };
            }

            await presenter.save(newTodo);

            expect(view.hideSpinner).toHaveBeenCalled();
            expect(view.showTodoCreated).toHaveBeenCalled();
        });
    });

    describe('when cancel new todo is requested', () => {
        it('cleans messages', async () => {
            presenter.cancel();

            expect(view.cleanMessages).toHaveBeenCalled();
        });

        it('redirects to place before', () => {
            presenter.cancel();

            expect(view.redirectToPageBefore).toHaveBeenCalled();
        });
    });
});
