describe("View Presenter", function(){
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
});
