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

    describe('when edit page is requested', function () {
        var pageEditionRequestedHandler = function () { };

        beforeEach(function () {
            view.subscribeToEditionPageRequested.and.callFake(function (handler) {
                pageEditionRequestedHandler = handler;
            });
        });
       
        it('redirects to page edition', function () {
            const pageId = 'page-id';
            presenter = new WiMi.Pages.Index.Presenter(view, client);

            pageEditionRequestedHandler(pageId);

            expect(view.redirecToEditionPage).toHaveBeenCalledWith(pageId);
        });
    });
});