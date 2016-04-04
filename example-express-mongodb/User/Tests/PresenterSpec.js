describe("View Presenter", function(){
  var client, view, presenter;

  beforeEach(function(){
    client = {
      getUsers: function(){}
    };
    view = {
      subscribesToUserAddingEvent: function(){},
      showErrorMessage:function(){},
      loadUsers: function(){}
    };
  });

  describe("when loads users", function(){

    it("shows error message if there is an error", function(){
      spyOn(client, "getUsers").and.callFake(function(successhandler, errorHandler){
        errorHandler();
      });
      spyOn(view, "showErrorMessage");

      presenter = new UserPresenter(view, client);

      expect(view.showErrorMessage).toHaveBeenCalled();
    });

    it("shows users", function(){
      spyOn(client, "getUsers").and.callFake(function(successhandler, errorHandler){
        successhandler();
      });
      spyOn(view, "loadUsers");

      presenter = new UserPresenter(view, client);

      expect(view.loadUsers).toHaveBeenCalled();
    });
  });
});
