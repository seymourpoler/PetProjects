(function (WiMi) {

    function Presenter(id, view, client) {
        var self = this;

        console.log(id);

        view.subscribeToDeletingPageRequested(deletingPageRequestedHandler);
        function deletingPageRequestedHandler() {
            view.showSpinner();
            client.delete(id, successHandler, errorHandler);
  
            function successHandler() {
                throw 'not implemented';
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
            throw 'not implemented';
        };

        self.showSpinner = function () {
            throw 'not implemented';
        };

        self.hideSpinner = function () {
            throw 'not implemented';
        };

        self.showInternalServerError = function () {
            throw 'not implemented';
        };

        self.showErrors = function (errors) {
            throw 'not implemented';
        };
    }

    function Client(http) {
        var self = this;

        self.delete = function (id, successHandler, errorHandler) {
            throw 'not implemented';
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