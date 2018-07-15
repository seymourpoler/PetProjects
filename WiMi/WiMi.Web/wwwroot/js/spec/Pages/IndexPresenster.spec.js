describe('Index Presenter', function () {
    var presenter, view, client;

    beforeEach(function () {
        view = WiMi.Pages.Index.createIndexView();
        WiMi.spyAllMethodsOf(view);
        client = WiMi.Pages.Index.createIndexClient();
        WiMi.spyAllMethodsOf(client);
    });

    describe('when creation new page is requested', function () {
        var creationPageRequestedHandler = function () { };

        beforeEach(function () {
            view.subscribeToCreationPageRequested.and.callFake(function (handler) {
                creationPageRequestedHandler = handler;
            });
        });

        it('shows an error if there is an internal server error', function () {
            const title = 'title';
            const body = 'body';
            view.getTitle.and.returnValue(title);
            view.getBody.and.returnValue(body);
            client.save.and.callFake(function (request, successHandler, errorHandler) {
                expect(request.title).toBe(title);
                expect(request.body).toBe(body);
                errorHandler({ statusCode: WiMi.httpStatusCode.internalServerError, errors: [] })
            });
            presenter = new WiMi.Pages.Index.IndexPresenter(view, client);

            creationPageRequestedHandler();

            expect(view.showInternalServerError).toHaveBeenCalled();
        });   
    });
});