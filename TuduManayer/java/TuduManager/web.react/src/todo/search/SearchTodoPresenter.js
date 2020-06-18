import { createSearchTodoService } from './SearchTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';

export function SearchTodoPresenter(view, searchService) {
    let self = this;

    self.search = async (textSearch) => {
        const result = await searchService.search(textSearch);
        if(result.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        const todos = result.todos;
        view.showTodos(todos);
    }

    self.createNewTodo = () => {
        view.redirectToCreateNewTodo();
    };
}

export function createSearchTodoPresenter(view) {
    const service = createSearchTodoService();
    return new SearchTodoPresenter(view, service);
}