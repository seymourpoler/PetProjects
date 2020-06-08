import { createHttp, http } from '../../Http';

export function SearchTodoService(http){
    let self = this;

    self.search = async (text) => {
        throw 'not implemented';
    }
}


export function createSearchTodoService(){
	const http = createHttp();
    return new SearchTodoService(http);
}
