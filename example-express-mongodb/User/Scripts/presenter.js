'use strict';

function UserPresenter(view, client){
  view.subscribesToUserCreatingEvent(userCreatingEventHandler);
  view.subscribesToUserDeletingEvent(userDeletingEventHandler);
  loadUsers();


  function loadUsers(){
    view.clean();
    client.getUsers(loadUserSuccessHandler, loadUserErrorHandler);

    function loadUserSuccessHandler(users){
      view.loadUsers(users);
    }
    function loadUserErrorHandler(users){
      view.showErrorMessage('error loading users.');
    }
  }

  function userCreatingEventHandler(user){
    client.createUser(user, createUserSuccessHandler, createUserErrorHandler)

    function createUserSuccessHandler(){
      loadUsers();
    }

    function createUserErrorHandler(){
      view.showErrorMessage('error creating user.');
    }
  }

  function userDeletingEventHandler(userId){
    client.deleteUser(userId, deletingEventSuccessHandler, deletingEventErrorHandler);

    function deletingEventSuccessHandler(){
      loadUsers();
    }

    function deletingEventErrorHandler(){
      view.showErrorMessage('error creating user.');
    }
  }
}

function UserView(){
  var userDeletingEventHandler = function() {};
  this.subscribesToUserCreatingEvent = function(handler){
    $('#btnSave').click(function(){
      handler(
        $('#txtNewUserName').val());
    });
  };

  this.subscribesToUserDeletingEvent = function (handler){
    userDeletingEventHandler = handler;
  };

  function attachDeletingUserEvent(handler){
    $('.remove').click(function(){
      handler($(this)[0].id);
    });
  }

  this.loadUsers = function(users){
    $("#lstUsers").empty();
    _(users).each(function(user){
      $("#lstUsers").append(
        $("<li id='" + user._id + "'>" + user.name + " <a id='" + user._id + "' class='remove'>X</a></li>"));
    });
    attachDeletingUserEvent(userDeletingEventHandler);
  };

  this.clean = function(){
    $('#lblErrorMessage').empty();
    $('#lblErrorMessage').hide();
    $('#txtNewUserName').val('');
  }

  this.showErrorMessage = function(message){
    $('#lblErrorMessage').show(message);
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

  this.deleteUser = function(userId, successHandler, errorHandler){

  };
}

function createUserPresenter(){
  return new UserPresenter(
    new UserView(),
    new UserClient());
}
