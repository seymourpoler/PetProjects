'use strict';
function UserPresenter(view){
  loadUsers();

  function loadUsers(){
    $.get( "/api/Users")
    .done(function(data) {
      view.loadUsers(data.user);
    })
    .fail(function(error) {
      view.showErrorMessage('error loading users');
    });
  }
}

function UserView(){
  var userAddingEventHandler = function(){};
  this.subscribesToUserAddingEvent = function(handler){
    userAddingEventHandler = handler;
  };
  this.loadUsers = function(users){
    $("#lstUsers").empty();
    _(users).each(function(user){
      $("#lstUsers").append($("<li id='" + user._id + "'>").text(user.name));
    });
  };

  this.showErrorMessage = function(message){
    $('lblErrorMessage').show(message);
  };
}

function createUserPresenter(){
  return new UserPresenter(
    new UserView());
}
