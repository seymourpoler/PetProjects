describe("View Presenter", function(){
  var client, view, presenter;
  beforeEach(function(){
    client = {
      getUsers: function(){}
    };
    view = {
      showErrorMessage:function(){},
      subscribesToUserAddingEvent: function(){}
    };
  });
  describe("when loads users", function(){
    it("show error message if there is an error", function(){
      spyOn(client, "getUsers").and.callFake(function(successhandler, errorHandler){
        errorHandler();
      });
      spyOn(view, "showErrorMessage");

      presenter = new UserPresenter(view, client);

      expect(view.showErrorMessage).toHaveBeenCalled();
    });
  });
});
