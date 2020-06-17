import { createSearchTodoView } from './SearchTodoView';
import { SearchTodoService, createSearchTodoService } from './SearchTodoService';
import { SearchTodoPresenter } from './SearchTodoPresenter';
import { spyAllMethodsOf } from '../../Testing';
import { Http, createHttp } from '../../Http';
import { HttpStatusCode } from '../../HttpStatusCode';


describe('Search Todo Presenter', () =>{
    let view, service, presenter, http;

     beforeEach(() => {
        http = createHttp();
        spyAllMethodsOf(http);
        view = createSearchTodoView();
        spyAllMethodsOf(view);
        service = new SearchTodoService(http);
        presenter = new SearchTodoPresenter(view, service);
     });

    describe('when search is requested', () => {
        it('shows error if there is an internal server error', async () => {
            const searchText = 'tonight';
            http.get = () => { return { statusCode: HttpStatusCode.internalServerError }; };

            await presenter.search(searchText);

            expect(view.showInternalServerError).toHaveBeenCalled();
        });

        it('shows todos', async () => {
            const todos = [{id:1, title: 'a title'}, {id:2, title: 'another title'}];
            const searchText = 'tonight';
            http.get = () => { return { statusCode: HttpStatusCode.ok, body: todos }; };

            await presenter.search(searchText);

            expect(view.showTodos).toHaveBeenCalledWith(todos);
        });
    });

    describe('when creation a new todo is requested', () => {
        it('redirects to a creation of a new todo', () => {
            presenter.createNewTodo();

            expect(view.redirectToCreateNewTodo).toHaveBeenCalled();
        });
    });
});