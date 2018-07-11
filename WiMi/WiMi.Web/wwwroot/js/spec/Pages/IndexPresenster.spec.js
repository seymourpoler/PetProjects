describe('Index Presenter', function () {
    var presenter, view, client;
    beforeEach(function () {
        view = WiMi.Pages.createIndexView();
        WiMi.spyAllMethodsOf(view);
        client = WiMi.Pages.createIndexClient();
        WiMi.spyAllMethodsOf(client);
        presenter = new WiMi.Pages.IndexPresenter(view, client);
    });
    describe('when creation new page is requested', function () {
        it('shows an error if there is an error', function () {
            expect(true).toBe(false);
        });
    });
});