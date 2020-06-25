export function EditTodoPresenter(view){
    let self = this;

    self.update = (todo) => {
        view.cleanMessages();
    }
}

export function createEditTodoPresenter(view) {
    return new EditTodoPresenter(view);
}