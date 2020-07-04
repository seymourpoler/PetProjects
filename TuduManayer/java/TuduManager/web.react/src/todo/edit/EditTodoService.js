import {HttpStatusCode} from "../../HttpStatusCode";
import {createHttp} from "../../Http";

export function EditTodoService(http){
    let self = this;

    self.update = async function(todo) {
        const url = '/api/todos';
        const response = await http.put(url, JSON.stringify(todo));
        if(response.statusCode === HttpStatusCode.internalServerError){
            return {
                statusCode: response.statusCode
            }
        }
        if(response.statusCode === HttpStatusCode.badRequest){
            return {
                statusCode: response.statusCode,
                errors: response.body
            }
        }
        throw 'not implemented';
    }
}

export function createEditTodoService() {
    const http = createHttp();
    return new EditTodoService(http);
}