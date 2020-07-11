import {createHttp} from "../../Http";
import {HttpStatusCode} from "../../HttpStatusCode";

export function ManageTodoService(http){
    let self = this;
    
    self.search = async (text) => {
        const url = '/api/todos?text=' + text;
        const response = await http.get(url);
        if(response.statusCode === HttpStatusCode.internalServerError){
            return { statusCode: HttpStatusCode.internalServerError};
        }
        
        return { 
            statusCode: HttpStatusCode.ok,
            todos: response.body
        };
    }
}

export function createManageTodoService() {
    const http = createHttp();
    return new ManageTodoService(http);
}