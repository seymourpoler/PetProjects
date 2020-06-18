import { createSearchTodoService } from './SearchTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';

export function SearchTodoPresenter(view, searchService) {
    let self = this;

    self.search = async (textSearch) => {
        view.cleanMessages();
        view.showSpinner();
        const result = await searchService.search(textSearch);
        view.hideSpinner();

        if(result.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        view.showTodos(result.todos);
    }

    self.createNewTodo = () => {
        view.redirectToCreateNewTodo();
    };
}

export function createSearchTodoPresenter(view) {
    const service = createSearchTodoService();
    return new SearchTodoPresenter(view, service);
}