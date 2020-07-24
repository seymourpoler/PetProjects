import { createSearchTodoService } from './SearchTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';

export function createManageTodoPresenter(view, searchService = createSearchTodoService()) {
    let self = {};

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
    }

    self.editTodo = (todoId) => {
        view.redirectToEditTodo(todoId);
    }

    self.deleteTodo = async function(todoId) {
        view.cleanMessages();
        view.showSpinner();

        const response = await searchService.delete(todoId);
        if(response.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        throw 'not implemented';
    }

    return self;
}