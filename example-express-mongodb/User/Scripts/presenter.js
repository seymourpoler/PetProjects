'use strict';

function UserPresenter(view, client){
  view.subscribesToUserCreatingEvent(subscribesToUserCreatingEventHandler);
  loadUsers();

  function loadUsers(){
    client.getUsers(loadUserSuccessHandler, loadUserErrorHandler);

    function loadUserSuccessHandler(users){
      view.loadUsers(users);
    }
    function loadUserErrorHandler(users){
      view.showErrorMessage('error loading users.');
    }
  }

  function subscribesToUserCreatingEventHandler(user){
    client.createUser(user, createUserSuccessHandler, createUserErrorHandler)

    function createUserSuccessHandler(){
      loadUsers();
    }

    function createUserErrorHandler(){
      view.showErrorMessage('error creating user.');
    }
  }
}

function UserView(){
  var userCreatingEventHandler = function(){};

  this.subscribesToUserCreatingEvent = function(handler){
    userCreatingEventHandler = handler;
    $('#btnSave').click(function(){
      userCreatingEventHandler(
        $('#txtNewUserName').val());
    });
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

  this.createUser = function(userName, successHandler, errorHandler){
    $.post( "/api/Users", {name: userName})
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
    new UserClient());
}
