import { createCreateTodoService } from './CreateTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';

export function CreateTodoPresenter(view, service){
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
        view.cleanMessages();
        view.redirectToPageBefore();
    }
}

export function createCreateTodoPresenter(view){
    const service = createCreateTodoService();
    return new CreateTodoPresenter(view, service);
}
