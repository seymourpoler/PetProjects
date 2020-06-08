export function SearchTodoService(){
    let self = this;

    self.search = async (text) => {
        throw 'not implemented';
    }
}


export function createSearchTodoService(){
    return new SearchTodoService();
}