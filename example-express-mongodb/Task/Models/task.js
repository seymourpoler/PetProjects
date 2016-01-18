'use strict';
function Task(state){
  var id = state.id;
  var title = state.title;

  this.Id = function(){
    return id;
  };
  
  this.Title = function(){
    return title;
  };
}
