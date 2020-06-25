export function EditTodoPresenter(view){
    let self = this;

    self.update = (todo) => {
        view.cleanMessages();
        view.showSpinner();
    }
}

export function createEditTodoPresenter(view) {
    return new EditTodoPresenter(view);
}