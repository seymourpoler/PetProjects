describe('Presenter', function () {
    var presenter, view, client;

    beforeEach(function () {
        view = WiMi.Pages.Index.createView();
        WiMi.spyAllMethodsOf(view);
        client = WiMi.Pages.Index.createClient();
        WiMi.spyAllMethodsOf(client);
    });

    it('show all pages', function () {
        var pages = [];
        client.find.and.callFake(function (successHandler, errorHandler) {
            successHandler(pages);
        });
        presenter = new WiMi.Pages.Index.Presenter(view, client);

        expect(view.showPages).toHaveBeenCalledWith(pages);
    });
});