'use strict';
describe("User Presenter", function(){
  var client, view, presenter;

  beforeEach(function(){
    client = new UserClient();
    spyOnAllMethodsOf(client);
    view = new UserView();
    spyOnAllMethodsOf(view);
  });

  describe("when loads users", function(){

    it("shows error message if there is an error", function(){
      client.getUsers.and.callFake(function(successhandler, errorHandler){
        errorHandler();
      });

      presenter = new UserPresenter(view, client);

      expect(view.showErrorMessage).toHaveBeenCalled();
    });

    it("shows users", function(){
      client.getUsers.and.callFake(function(successhandler, errorHandler){
        successhandler();
      });

      presenter = new UserPresenter(view, client);

      expect(view.loadUsers).toHaveBeenCalled();
    });
  });

  describe("when new user is creating", function(){

    it("shows an error if there is an error", function(){
      debugger;
      var userCreatingEventHandler = function(){};
      var userCreatingRequest = {name: 'john'};
      view.subscribesToUserCreatingEvent.and.callFake(function(handler){
        userCreatingEventHandler = handler;
      });
      client.createUser.and.callFake(function(user, successHandler, errorHandler){
        errorHandler();
      });
      presenter = new UserPresenter(view, client);

      userCreatingEventHandler(userCreatingRequest);

      expect(view.showErrorMessage).toHaveBeenCalled();
    });
  });
});
