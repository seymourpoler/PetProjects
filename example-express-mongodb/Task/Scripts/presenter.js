function TaskPresenter(){
  console.log('hello from TaskPresenter');
}

function TaskView(){
  console.log('hello from TaskView');
}

function createTaskPresenter(){
  return new TaskPresenter(
    new TaskView());
}
