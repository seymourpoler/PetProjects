export function SearchTodoPresenter(view){
    let self = this;

    self.search = async (search) => {
        view.showInternalServerError();
        //throw 'not implemented';
    }
}

export function createSearchTodoPresenter(view){
    return new SearchTodoPresenter(view);
}