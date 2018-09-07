(function (WiMi) {

    function Presenter(id, view, client) {
        var self = this;

        view.subscribeToDeletingPageRequested(deletingPageRequestedHandler);
        function deletingPageRequestedHandler() {
            view.showSpinner();
            client.delete(id, successHandler, errorHandler);
  
            function successHandler() {
                view.hideSpinner();
                view.redirectToIndexPage();
            }

            function errorHandler(response) {
                view.hideSpinner();
                if (response.status === WiMi.httpStatusCode.internalServerError) {
                    view.showInternalServerError();
                    return;
                }
                if (response.status === WiMi.httpStatusCode.badRequest) {
                    view.showErrors(response.errors);
                    return;
                }
                throw 'not implemented';
            }
        }
        view.subscribeToClosingPageRequested(closingPageRequestedHandler);
        function closingPageRequestedHandler() {
            view.redirectToIndexPage();
        }
        view.subscribeToUpdatingPageRequested(updatingPageRequestedHandler);
        function updatingPageRequestedHandler() {
            view.showSpinner();
            const request = {
                id: id,
                title: view.getTitle(),
                body: view.getBody()
            };
            client.update(request, successHandler, errorHandler);
            function successHandler() {
                view.hideSpinner();
                view.showUpdatedPageMessage();
            }

            function errorHandler(response) {
                view.hideSpinner();
                if (response.status === WiMi.httpStatusCode.internalServerError) {
                    view.showInternalServerError();
                    return;
                }
                if (response.status === WiMi.httpStatusCode.badRequest) {
                    view.showErrors(response.errors);
                    return;
                }
                throw 'not implemented';
            }
        }
    }

    function View() {
        var self = this;

        self.subscribeToDeletingPageRequested = function (handler) {
            self._btnDelete.on('click', handler);
        };

        self.subscribeToClosingPageRequested = function (handler) {
            self._btnClose.on('click', handler);
        };

        self.subscribeToUpdatingPageRequested = function (handler) {
            self._btnSave.on('click', handler);
        };

        self.showSpinner = function () {
            self._spinner.show();
        };

        self.hideSpinner = function () {
            self._spinner.hide();
        };

        self.getTitle = function () {
            self._txtTitle.getText();
        };

        self.getBody = function () {
            self._txtBody.getText();
        };

        self.showInternalServerError = function () {
            self._lblError.showText('internal server error');
        };

        self.showErrors = function (errors) {
            self._lblError.showText(errors);
        };

        self.showUpdatedPageMessage = function () {
            self._lblInformation.setText('page updated');
        };

        self.redirectToIndexPage = function () {
            self._redirector.redirect('/pages/index');
        };
    }

    function Client(http) {
        var self = this;

        self.delete = function (id, successHandler, errorHandler) {
            http.delete('/api/pages/' + id, successHandler, errorHandler);
        };

        self.update = function (request, successHandler, errorHandler) {
            http.put('/api/pages', request, successHandler, errorHandler);
        };
    }

    function createPresenter(id) {
        return new WiMi.Pages.Edit.Presenter(
            id,
            WiMi.Pages.Edit.createView(),
            WiMi.Pages.Edit.createClient());
    }

    function createView() {
        var view = new WiMi.Pages.Edit.View();
        view._txtTitle = new Peper.InputText('txtTitle');
        view._txtBody = new Peper.InputText('txtBody');
        view._btnSave = new Peper.Button('btnSave');
        view._btnClose = new Peper.Button('btnClose');
        view._btnDelete = new Peper.Button('btnDelete');
        view._lblInformation = new Peper.Label('lblInformation');
        view._lblError = new Peper.Label('lblError');
        view._redirector = new Peper.Redirector();
        view._spinner = new Peper.Panel('spinner');
        return view;
    }

    function createClient() {
        return new WiMi.Pages.Edit.Client(new WiMi.Http());
    }

    WiMi.namespace("Pages.Edit");
    WiMi.Pages.Edit.Presenter = Presenter;
    WiMi.Pages.Edit.createPresenter = createPresenter;
    WiMi.Pages.Edit.View = View;
    WiMi.Pages.Edit.createView = createView;
    WiMi.Pages.Edit.Client = Client;
    WiMi.Pages.Edit.createClient = createClient;

})(WiMi || {});