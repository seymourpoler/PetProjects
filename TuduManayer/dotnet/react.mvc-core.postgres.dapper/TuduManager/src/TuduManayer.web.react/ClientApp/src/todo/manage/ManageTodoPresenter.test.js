import { createManageTodoView } from "./ManageTodoView";
import { ManageTodoPresenter } from "./ManageTodoPresenter";
import { ManageTodoService } from './ManageTodoService'
import { spyAllMethodsOf } from "../../Testing";
import { createHttp } from "../../Http";
import { HttpStatusCode } from '../../HttpStatusCode';

describe('Manage Todo Presenter', function() {
    let view, presenter, service, http;
    
    beforeEach(function() {
        view = createManageTodoView();
        spyAllMethodsOf(view);
        http = createHttp();
        spyAllMethodsOf(http);
        service = new ManageTodoService(http);
        presenter = new ManageTodoPresenter(view, service);
    });
    
    describe('when search is requested', function() {
        it('cleans messages', function() {
            const searchText = 'text'
            
            presenter.search(searchText);
            
            expect(view.cleanMessages).toHaveBeenCalled();
        });

        it('show spinner', function() {
            const searchText = 'text'

            presenter.search(searchText);

            expect(view.showSpinner).toHaveBeenCalled();
        });
        
        it('shows error if there is an internal server error', async () => {
            const searchText = 'text'
            http.get = () => {
                return {statusCode: HttpStatusCode.internalServerError};
                
            };
            
            await presenter.search(searchText);

            expect(view.showInternalServerErrorMessage).toHaveBeenCalled();
        });

        it('shows todos', async () => {
            const searchText = 'text'
            const todos = [];
            http.get = () => {
                return { statusCode: HttpStatusCode.ok, body: todos };
            };

            await presenter.search(searchText);

            expect(view.show).toHaveBeenCalledWith(todos);
        });
    });
});