(function (WiMi) {
    function IndexPresenter(view, client) {
        var self = this;
        view.subscribeToCreationPageRequested(creationPageRequestedHandler);
        view.subscribeToClosingPageRequested(closingPageRequestedHandler);

        function creationPageRequestedHandler() {
            const title = view.getTitle();
            const body = view.getBody();
            const request = { title: title, body: body };
            client.save(request, successHandler, errorHandler);
            function errorHandler(response) {
                if (response.statusCode === WiMi.httpStatusCode.internalServerError) {
                    view.showInternalServerError();
                    return;
                }
                if (response.statusCode === WiMi.httpStatusCode.badRequest) {
                    view.showErrors(response.errors);
                    return;
                }
                throw 'not implemented';
            }
            function successHandler() {
                view.showCreatedPageMessage();
            }
        }

        function closingPageRequestedHandler(){
            view.redirectToPageBefore();
        }
    }

    function IndexView() {
        var self = this;
        var creationPageRequestedHandler = function () { };
        var closingPageRequestedHandler = function(){};

        self.subscribeToCreationPageRequested = function (handler) {
            creationPageRequestedHandler = handler;
        };

        self.subscribeToClosingPageRequested = function(handler){
            closingPageRequestedHandler = handler;
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

        self.redirectToPageBefore = function(){
            throw 'not implemented';
        };
    }

    function IndexClient(http) {
        var self = this;

        self.save = function (request, successHandler, errorHandler) {
            http.post('/pages', request, successHandler, errorHandler);
        };
    }

    function createIndexPresenter() {
        return new WiMi.Pages.Index.IndexPresenter(
            WiMi.Pages.Index.createIndexView(),
            WiMi.Pages.Index.createIndexClient());
    }

    function createIndexView() {
        var view = new WiMi.Pages.Index.IndexView();
        view._txtTitle = new Peper.InputText('txtTitle');
        view._txtBody = new Peper.InputText('txtBody');
        view._btnCreate = new Peper.Button('btnCreate');
    }

    function createIndexClient() {
        return new WiMi.Pages.Index.IndexClient(new WiMi.Http());
    }
    
    WiMi.namespace("Pages.Index");
    WiMi.Pages.Index.IndexPresenter = IndexPresenter;
    WiMi.Pages.Index.createIndexPresenter = createIndexPresenter;
    WiMi.Pages.Index.IndexView = IndexView;
    WiMi.Pages.Index.createIndexView = createIndexView;
    WiMi.Pages.Index.IndexClient = IndexClient;
    WiMi.Pages.Index.createIndexClient = createIndexClient;
})(WiMi || {})