import { createHttp } from '../../Http';
import { HttpStatusCode } from '../../HttpStatusCode';

export function NewTodoService(http){
    let self = this;

    self.save = async (todo) => {
        const url = 'api/todos';
        const response = await http.post(url, todo);
        if(response.statusCode === HttpStatusCode.internalServerError){
            return { statusCode: HttpStatusCode.internalServerError };
        }
        //throw 'not implemented';
    };
}

export function createNewTodoService(){
    const http = createHttp();
    return new NewTodoService(http);
}
