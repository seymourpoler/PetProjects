(function (WiMi) {
    function IndexPresenter(view, client) {
        var self = this;
        view.subscribeToCreationPageRequested(creationPageRequestedHandler);

        function creationPageRequestedHandler() {
            const title = view.getTitle();
            const body = view.getBody();
            const request = { title: title, body: body };
            client.save(request, successHandler, errorHandler);
            function errorHandler(response) {
                if (response.statusCode == WiMi.httpStatusCode.internalServerError) {
                    view.showInternalServerError();
                    return;
                }
                if (response.statusCode == WiMi.httpStatusCode.badRequest) {
                    view.showErrors(response.errors);
                    return;
                }
                throw 'not implemented';
            }
            function successHandler() {
                view.showCreatedPageMessage();
            }
        }
    }

    function IndexView(view, client) {
        var self = this;
        var creationPageRequestedHandler = function () { };

        self.subscribeToCreationPageRequested = function (handler) {
            creationPageRequestedHandler = handler;
        };

        self.getTitle = function () {
            throw 'not implemented';
        };

        self.getBody = function () {
            throw 'not implemented';
        };

        self.showInternalServerError = function () {
            throw 'not implemented';
        };

        self.showErrors = function (errors) {
            throw 'not implemented';
        };

        self.showCreatedPageMessage = function(){
            throw 'not implemented';
        };
    }

    function IndexClient(view, client) {
        var self = this;

        self.save = function (request, successHandler, errorHandler) {
            throw 'not implemented';
        };
    }

    function createIndexPresenter() {
        return new WiMi.Pages.Index.IndexPresenter(
            WiMi.Pages.Index.createIndexView(),
            WiMi.Pages.Index.createIndexClient());
    }

    function createIndexView() {
        return new WiMi.Pages.Index.IndexView();
    }

    function createIndexClient() {
        return new WiMi.Pages.Index.IndexClient();
    }
    
    WiMi.namespace("Pages.Index");
    WiMi.Pages.Index.IndexPresenter = IndexPresenter;
    WiMi.Pages.Index.createIndexPresenter = createIndexPresenter;
    WiMi.Pages.Index.IndexView = IndexView;
    WiMi.Pages.Index.createIndexView = createIndexView;
    WiMi.Pages.Index.IndexClient = IndexClient;
    WiMi.Pages.Index.createIndexClient = createIndexClient;
})(WiMi || {})