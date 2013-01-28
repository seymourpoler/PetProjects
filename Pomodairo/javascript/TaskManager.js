function Task(namenewTask){
  this.guid = generateNewGUID();
  this.name = namenewTask;
  this.minutes = 0;
  this.numberOfPomodoros = 0;

  function generateNewGUID ()
  {
      var S4 = function ()
      {
          return Math.floor(
                  Math.random() * 0x10000 /* 65536 */
              ).toString(16);
      };

      return (
              S4() + S4() + "-" +
              S4() + "-" +
              S4() + "-" +
              S4() + "-" +
              S4() + S4() + S4()
          );
  }
}

function TaskManager(){
  this.tasks = [];

  this.saveNewTask = function(task){
    this.tasks.push(task);
  }
  this.removeTaskByGuid = function(task){
    var aux;
    var position = 0;
    var actualTask;
    var resultTask;
    while (position < tasks.length) {
      actualTask = tasks[position];
      if(actualTask.guid != task.guid){
        resultTask.push(actualTask);
      }
      position ++;
    }
    this.tasks = resultTask;
  }
  this.getAlltasks = function(){
    return this.tasks;
  }
}