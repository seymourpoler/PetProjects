import { createNewTodoService } from './NewTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';


export function NewTodoPresenter(view, service){
    let self = this;

    self.save = async (todo) => {
        view.cleanMessages();
        view.showSpinner();
        const result = await service.save(todo);
        view.hideSpinner();
        if(result.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        if(result.statusCode === HttpStatusCode.badRequest){
            view.showErrors(result.errors);
            return;
        }
        view.showTodoCreated();
    };

    self.cancel = () => {
        view.redirectToPageBefore();
    }
}

export function createNewTodoPresenter(view){
    const service = createNewTodoService();
    return new NewTodoPresenter(view);
}
