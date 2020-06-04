export function SearchTodoService(){
    let self = this;

    self.search = () => {
        throw 'not implemented';
    }
}


export function createSearchTodoService(){
    return new SearchTodoService();
}