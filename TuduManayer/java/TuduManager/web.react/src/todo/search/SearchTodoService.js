import { createHttp, http } from '../../Http';
import { HttpStatusCode } from '../../HttpStatusCode';

export function SearchTodoService(http){
    let self = this;

    self.search = async (text) => {
        const response = await http.get();
        if(response.statusCode === HttpStatusCode.internalServerError){
            return  {
                statusCode: HttpStatusCode.internalServerError
            };
        }
        throw 'not implemented';
    }
}


export function createSearchTodoService(){
	const http = createHttp();
    return new SearchTodoService(http);
}
