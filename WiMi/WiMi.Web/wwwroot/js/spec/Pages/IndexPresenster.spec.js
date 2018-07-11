describe('Index Presenter', function () {
    var presenter, view, client;
    beforeEach(function () {
        view = WiMi.Pages.Index.createIndexView();
        WiMi.spyAllMethodsOf(view);
        client = WiMi.Pages.Index.createIndexClient();
        WiMi.spyAllMethodsOf(client);
        presenter = new WiMi.Pages.Index.IndexPresenter(view, client);
    });
    describe('when creation new page is requested', function () {
        it('shows an error if there is an error', function () {
            expect(true).toBe(false);
        });
    });
});