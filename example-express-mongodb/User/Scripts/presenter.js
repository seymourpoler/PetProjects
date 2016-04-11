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
  var lblErrorMessage = new delta.Label('lblErrorMessage');
  var btnSave = new delta.Button('btnSave');
  var listOfUser = new delta.List('lstUsers');
  var txtNewUserName = new delta.TextBox('txtNewUserName');
  var userDeletingEventHandler = function() {};

  this.subscribesToUserCreatingEvent = function(handler){
    btnSave.onClick(function(){
      handler(txtNewUserName.getText());
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
    listOfUser.clear();
    _(users).each(function(user){
        listOfUser.addHtmlItem("<li id='" + user._id + "'>" + user.name + " <a id='" + user._id + "' class='remove'>X</a></li>");
    });
    attachDeletingUserEvent(userDeletingEventHandler);
  };

  this.clean = function(){
    lblErrorMessage.clear();
    lblErrorMessage.hide();
    txtNewUserName.clear();
  }

  this.showErrorMessage = function(message){
    lblErrorMessage.setText(message);
    lblErrorMessage.show();
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
    $.ajax({
      url: "/api/Users" + '/' + userId,
      type: 'DELETE'
    })
    .done(function(data) {
      successHandler();
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
