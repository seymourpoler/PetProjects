import { createEditTodoService } from "./EditTodoService";
import { HttpStatusCode } from "../../HttpStatusCode";

export function EditTodoPresenter(view, service){
    let self = this;

    self.load = async function(todoId){
        view.showSpinner();
    }

    self.update = async function(todo) {
        view.cleanMessages();
        view.showSpinner();
        const response = await service.update(todo);
        view.hideSpinner();
        if(response.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        if(response.statusCode === HttpStatusCode.badRequest){
            view.showErrors(response.errors);
            return;
        }
        view.showUpdatedTodoMessage();
    }

    self.cancel = function () {
        view.redirectToPageBefore();
    }
}

export function createEditTodoPresenter(view) {
    const service = createEditTodoService();
    return new EditTodoPresenter(view, service);
}