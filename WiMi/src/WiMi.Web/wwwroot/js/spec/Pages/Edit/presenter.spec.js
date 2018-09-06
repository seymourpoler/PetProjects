describe('edit Presenter', function () {
    var presenter, view, client;

    beforeEach(function () {
        view = WiMi.Pages.Edit.createView();
        WiMi.spyAllMethodsOf(view);
        client = WiMi.Pages.Edit.createClient();
        WiMi.spyAllMethodsOf(client);
    });

    describe('when page deleting is requested', function () {
        const id = 'page-id';
        let deletingPageRequestedHandler = function () { };

        beforeEach(function () {
            view.subscribeToDeletingPageRequested.and.callFake(function (handler) {
                deletingPageRequestedHandler = handler;
            });
        });

        it('shows an error message if there is an internal server error', function () {
            client.delete.and.callFake(function (id, successHandler, errorHandler) {
                expect(view.showSpinner).toHaveBeenCalled();
                errorHandler({ status: WiMi.httpStatusCode.internalServerError, errors: [] })
            });
            presenter = new WiMi.Pages.Edit.Presenter(id, view, client);

            deletingPageRequestedHandler();

            expect(view.showInternalServerError).toHaveBeenCalled();
            expect(view.hideSpinner).toHaveBeenCalled();

        });

        it('shows an error if there are errors', function () {
            const errors = [{ fieldId: 'General', errorCode: 'NotFound' }];
            client.delete.and.callFake(function (id, successHandler, errorHandler) {
                expect(view.showSpinner).toHaveBeenCalled();
                errorHandler({ status: WiMi.httpStatusCode.badRequest, errors: errors });
            });
            presenter = new WiMi.Pages.Edit.Presenter(id, view, client);

            deletingPageRequestedHandler();

            expect(view.showErrors).toHaveBeenCalledWith(errors);
            expect(view.hideSpinner).toHaveBeenCalled();

        });
    });
});