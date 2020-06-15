import { createSearchTodoService } from './SearchTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';

export function SearchTodoPresenter(view, searchService){
    let self = this;

    self.search = async (textSearch) => {
        const result = await searchService.search(textSearch);
        if(result.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        if(result.statusCode === 400){
            return view.showErrors(result.errors);
        }
        const todos = result.todos;
        view.showTodos(todos);
    }
}

export function createSearchTodoPresenter(view){
    const service = createSearchTodoService();
    return new SearchTodoPresenter(view, service);
}