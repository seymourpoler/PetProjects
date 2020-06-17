import { createHttp, http } from '../../Http';
import { HttpStatusCode } from '../../HttpStatusCode';

export function SearchTodoService(http){
    let self = this;

    self.search = async (text) => {
        const url = '/api/todos?searchText=' + text;
        const response = await http.get(url);
        if(response.statusCode   === HttpStatusCode.internalServerError){
            return  {
                statusCode: HttpStatusCode.internalServerError
            };
        }

        return {
            statusCode: HttpStatusCode.ok,
            todos: response.body
        }
    }
}


export function createSearchTodoService(){
	const http = createHttp();
    return new SearchTodoService(http);
}
