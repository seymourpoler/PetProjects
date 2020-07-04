import { createEditTodoService } from "./EditTodoService";
import {HttpStatusCode} from "../../HttpStatusCode";

export function EditTodoPresenter(view, service){
    let self = this;

    self.update = async function(todo) {
        view.cleanMessages();
        view.showSpinner();
        const response = await service.update(todo);
        if(response.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        throw 'not implemented';
    }
}

export function createEditTodoPresenter(view) {
    const service = createEditTodoService();
    return new EditTodoPresenter(view, service);
}