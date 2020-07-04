import {HttpStatusCode} from "../../HttpStatusCode";
import {createHttp} from "../../Http";

export function EditTodoService(http){
    let self = this;

    self.update = async function(todo) {
        const url = '/api/todos';
        const response = await http.put(url, JSON.stringify(todo));
        if(response.statusCode === HttpStatusCode.internalServerError){
            return {
                statusCode: HttpStatusCode.internalServerError
            }
        }
        throw 'not implemented';
    }
}

export function createEditTodoService() {
    const http = createHttp();
    return new EditTodoService(http);
}