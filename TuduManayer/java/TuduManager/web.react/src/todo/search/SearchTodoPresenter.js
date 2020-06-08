export function SearchTodoPresenter(view, searchService){
    let self = this;

    self.search = async (textSearch) => {
        const result = await searchService.search(textSearch);
        if(result.statusCode == 500){
            view.showInternalServerError();
            return;
        }
        if(result.statusCode === 400){
            return view.showErrors(result.errors);
        }
        //throw 'not implemented';
    }
}

export function createSearchTodoPresenter(view){
    return new SearchTodoPresenter(view);
}