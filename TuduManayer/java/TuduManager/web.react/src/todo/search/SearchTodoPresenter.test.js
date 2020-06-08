import { createSearchTodoView } from './SearchTodoView';
import { createSearchTodoService } from './SearchTodoService';
import { SearchTodoPresenter } from './SearchTodoPresenter';
import { spyAllMethodsOf } from '../../Testing';


describe('Search Todo Presenter', () =>{
    let view, service, presenter;

     beforeEach(() => {
        view = createSearchTodoView();
        spyAllMethodsOf(view);
        service = createSearchTodoService();
        spyAllMethodsOf(service);
        presenter = new SearchTodoPresenter(view, service);
     });

    describe('when search is requested', () => {
        it('shows error if there is an internal server error', async () => {
            const searchText = 'tonight';
            service.search = async (searchText) => { return { statusCode: 500 }; };

            await presenter.search(searchText);

            expect(view.showInternalServerError).toHaveBeenCalled();
        });

        it('shows errors if there are errors', async () => {
            const errors = [{fieldId: 'searchText', errorCode:'required'}];
            const searchText = 'tonight';
            service.search = async (searchText) => { return {statusCode: 400, errors}; };

            await presenter.search(searchText);

            expect(view.showErrors).toHaveBeenCalledWith(errors);
        });

        it('shows todos', async () => {
            const todos = [{id:1, title: 'a title'}, {id:2, title: 'another title'}];
            const searchText = 'tonight';
            service.search = async (searchText) => { return {statusCode: 200, todos}; };

            await presenter.search(searchText);

            expect(view.showTodos).toHaveBeenCalledWith(todos);
        });
    });
});