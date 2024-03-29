﻿describe('Edit Presenter', function () {
    let presenter, view, client;
    const id = 'page-id';

    beforeEach(function () {
        view = WiMi.Pages.Edit.createView();
        WiMi.spyAllMethodsOf(view);
        client = WiMi.Pages.Edit.createClient();
        WiMi.spyAllMethodsOf(client);
    });

    describe('when page closing is requested', function () {
        let closingPageRequestedHandler = function () { };
        it('redirects to index', function () {
            view.subscribeToClosingPageRequested.and.callFake(function (handler) {
                closingPageRequestedHandler = handler;
            });
            presenter = new WiMi.Pages.Edit.Presenter(id, view, client);

            closingPageRequestedHandler();

            expect(view.redirectToIndexPage).toHaveBeenCalled();
        });
    });

    describe('when page deleting is requested', function () {
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

        it('redirects to index if is deleted', function () {
            client.delete.and.callFake(function (id, successHandler, errorHandler) {
                expect(view.showSpinner).toHaveBeenCalled();
                successHandler();
            });
            presenter = new WiMi.Pages.Edit.Presenter(id, view, client);

            deletingPageRequestedHandler();

            expect(view.hideSpinner).toHaveBeenCalled();
            expect(view.redirectToIndexPage).toHaveBeenCalled();
        });
    });

    describe('when page updating is requested', function () {
        let updatingPageRequestedHandler = function () { };

        beforeEach(function () {
            view.subscribeToUpdatingPageRequested.and.callFake(function (handler) {
                updatingPageRequestedHandler = handler;
            });
        });

        it('shows an error message if there is an internal server error', function () {
            const request = {};
            client.update.and.callFake(function (request, successHandler, errorHandler) {
                expect(view.showSpinner).toHaveBeenCalled();
                errorHandler({ status: WiMi.httpStatusCode.internalServerError, errors: [] })
            });
            presenter = new WiMi.Pages.Edit.Presenter(id, view, client);

            updatingPageRequestedHandler();

            expect(view.showInternalServerError).toHaveBeenCalled();
            expect(view.hideSpinner).toHaveBeenCalled();

        });

        it('shows an error if there are errors', function () {
            const request = {};
            const errors = [{ fieldId: 'General', errorCode: 'NotFound' }];
            client.update.and.callFake(function (request, successHandler, errorHandler) {
                expect(view.showSpinner).toHaveBeenCalled();
                errorHandler({ status: WiMi.httpStatusCode.badRequest, errors: errors });
            });
            presenter = new WiMi.Pages.Edit.Presenter(id, view, client);

            updatingPageRequestedHandler();

            expect(view.showErrors).toHaveBeenCalledWith(errors);
            expect(view.hideSpinner).toHaveBeenCalled();
        });

        it('shows information if page is updated', function () {
            const body = 'body';
            const title = 'title';
            const request = {id: id, body: body, title: title };
            view.getBody.and.returnValue(body);
            client.update.and.callFake(function (request, successHandler, errorHandler) {
                expect(request.id).toBe(id);
                expect(request.body).toBe(body);
                expect(view.showSpinner).toHaveBeenCalled();
                successHandler();
            });
            presenter = new WiMi.Pages.Edit.Presenter(id, view, client);

            updatingPageRequestedHandler();

            expect(view.showUpdatedPageMessage).toHaveBeenCalledWith();
            expect(view.hideSpinner).toHaveBeenCalled();
        });
    });
});