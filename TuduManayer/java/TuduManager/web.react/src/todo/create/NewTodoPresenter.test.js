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
    });
});
