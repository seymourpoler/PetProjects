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
  this.loadUsers = function(users){
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
