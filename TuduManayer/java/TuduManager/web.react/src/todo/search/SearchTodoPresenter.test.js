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
        it('shows error if there is an internal server error', () => {
            service.search = () => { statusCode : 500 };
            const searchText = 'tonight';

            presenter.search(searchText);

            expect(view.showInternalServerError).toHaveBeenCalled();
        });
    });
});