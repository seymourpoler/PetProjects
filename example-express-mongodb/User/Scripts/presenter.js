'use strict';
function UserPresenter(view, client){
  view.subscribesToUserAddingEvent(subscribesToUserAddingEventHandler);
  loadUsers();

  function loadUsers(){
    client.getUsers(loadUserSuccessHandler, loadUserErrorHandler);

    function loadUserSuccessHandler(users){
      view.loadUsers(users);
    }
    function loadUserErrorHandler(users){
      view.showErrorMessage('error loading users');
    }
  }

  function subscribesToUserAddingEventHandler(user){

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

function UserClient(){
  this.getUsers = function(successHandler, errorHandler){
    $.get( "/api/Users")
    .done(function(data) {
      successHandler(data.user);
    })
    .fail(function(error) {
      errorHandler();
    });
  };
}

function createUserPresenter(){
  return new UserPresenter(
    new UserView(),
    new Client());
}
