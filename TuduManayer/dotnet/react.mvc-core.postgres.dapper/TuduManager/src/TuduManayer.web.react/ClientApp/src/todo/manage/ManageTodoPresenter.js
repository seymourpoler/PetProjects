import { createManageTodoService } from './ManageTodoService';
import { HttpStatusCode } from "../../HttpStatusCode";

export function ManageTodoPresenter(view, service){
    let self = this;
    
    self.search = async (searchText) => {
        view.cleanMessages();
        view.showSpinner();
        const response = await service.search(searchText);
        if(response.statusCode === HttpStatusCode.internalServerError){
            view.showInternalServerErrorMessage();
            return;
        }
        view.show(response.todos);       
    };
} 

export function createManageTodoPresenter(view){
    const service = createManageTodoService();
    return new ManageTodoPresenter(view, service);
}