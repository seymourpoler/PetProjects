'use strict';
function Task(state){
  var id = state.id;
  var title = state.title;

  this.getId = function(){
    return id;
  };

  this.getTitle = function(){
    return title;
  };
}

module.exports = Task;
