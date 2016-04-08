'use strict';
describe("User Presenter", function(){
  var client, view, presenter, allUsers;

  beforeEach(function(){
    client = new UserClient();
    spyOnAllMethodsOf(client);
    view = new UserView();
    spyOnAllMethodsOf(view);
    allUsers = [{_id:'idLuke',name:'luke'},{_id:'idJohn', name:'John'}];
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
      var allUsers = [{_id:'idLuke',name:'luke'},{_id:'idJohn', name:'John'}];
      client.getUsers.and.callFake(function(successhandler, errorHandler){
        successhandler(allUsers);
      });

      presenter = new UserPresenter(view, client);

      expect(view.loadUsers).toHaveBeenCalled();
    });
  });

  describe("when new user is creating", function(){
    var userCreatingEventHandler = function(){};
    var userCreatingRequest;
    beforeEach(function(){
      view.subscribesToUserCreatingEvent.and.callFake(function(handler){
        userCreatingEventHandler = handler;
      });
      userCreatingRequest = {name: 'john'};
    });

    it("shows an error if there is an error", function(){

      client.createUser.and.callFake(function(user, successHandler, errorHandler){
        errorHandler();
      });
      presenter = new UserPresenter(view, client);

      userCreatingEventHandler(userCreatingRequest);

      expect(view.showErrorMessage).toHaveBeenCalled();
    });

    it("loads all users if all rigth", function(){
      client.createUser.and.callFake(function(user, successHandler, errorHandler){
        successHandler();
      });
      client.getUsers.and.callFake(function(successHandler, errorHandler){
        successHandler(allUsers);
      });
      presenter = new UserPresenter(view, client);

      userCreatingEventHandler(userCreatingRequest);

      expect(view.loadUsers).toHaveBeenCalledWith(allUsers);
    });
  });
});
