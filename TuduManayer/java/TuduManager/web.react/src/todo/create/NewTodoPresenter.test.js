import { createNewTodoView } from './NewTodoView';
import { NewTodoPresenter } from './NewTodoPresenter';
import { NewTodoService } from './NewTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';
import { createHttp } from '../../Http';
import { spyAllMethodsOf } from '../../Testing';

describe('New Todo Presenter', () => {
    let view, presenter, service, http;

    beforeEach(() => {
        view = createNewTodoView();
        spyAllMethodsOf(view);
        http = createHttp();
        spyAllMethodsOf(http);
        service = new NewTodoService(http);
        presenter = new NewTodoPresenter(view, service);
    });

    describe('when save new todo is requested',() => {
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
            const errors = [];
            http.post = () => {
                expect(view.cleanMessage).toHaveBeenCalled();
                expect(view.showSpinner).toHaveBeenCalled();
                return { statusCode: HttpStatusCode.ok }
            };

            await presenter.save(newTodo);

            expect(view.hideSpinner).toHaveBeenCalled();
            expect(view.showTodoCreated).toHaveBeenCalled();
        });
    });

    describe('when cancel new todo is requested', () => {
        it('redirects to place before', () => {
            presenter.cancel();

            expect(view.redirectToPageBefore).toHaveBeenCalled();
        });
    });
});
