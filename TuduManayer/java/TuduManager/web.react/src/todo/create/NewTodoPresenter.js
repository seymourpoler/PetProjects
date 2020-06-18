import { createNewTodoService } from './NewTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';


export function NewTodoPresenter(view, service){
    let self = this;

    self.save = async (todo) => {
        const result = await service.save(todo);
        if(result.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerError();
            return;
        }
        throw 'not implemented';
    };
}

export function createNewTodoPresenter(view){
    const service = createNewTodoService();
    return new NewTodoPresenter(view);
}
