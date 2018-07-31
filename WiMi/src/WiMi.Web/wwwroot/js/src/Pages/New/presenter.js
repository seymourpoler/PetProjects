(function (WiMi) {
    function Presenter(view, client) {
        var self = this;
        view.subscribeToCreationPageRequested(creationPageRequestedHandler);
        view.subscribeToClosingPageRequested(closingPageRequestedHandler);

        function creationPageRequestedHandler() {
            const title = view.getTitle();
            const body = view.getBody();
            const request = { title: title, body: body };
            client.save(request, successHandler, errorHandler);
            function errorHandler(response) {
                if (response.status === WiMi.httpStatusCode.internalServerError) {
                    view.showInternalServerError();
                    return;
                }
                if (response.status === WiMi.httpStatusCode.badRequest) {
                    view.showErrors(response.errors);
                    return;
                }
            }
            function successHandler() {
                view.showCreatedPageMessage();
            }
        }

        function closingPageRequestedHandler(){
            view.redirectToPageBefore();
        }
    }

    function View() {
        var self = this;
        var creationPageRequestedHandler = function () { };
        var closingPageRequestedHandler = function(){};

        self.subscribeToCreationPageRequested = function (handler) {
            creationPageRequestedHandler = handler;
            self._btnCreate.on('click', creationPageRequestedHandler);
        };

        self.subscribeToClosingPageRequested = function(handler){
            closingPageRequestedHandler = handler;
            self._btnClose.on('click', closingPageRequestedHandler);
        };


        self.getTitle = function () {
            return self._txtTitle.getText();
        };

        self.getBody = function () {
            return self._txtBody.getText();
        };

        self.showInternalServerError = function () {
            self._lblError.show();
        };

        self.showErrors = function (errors) {
            self._lblError.show();
        };

        self.showCreatedPageMessage = function(){
            self._lblInformation.showText('page saved');
        };

        self.redirectToPageBefore = function(){
            window.history.back();
        };
    }

    function Client(http) {
        var self = this;

        self.save = function (request, successHandler, errorHandler) {
            http.post('/api/pages', request, successHandler, errorHandler);
        };
    }

    function createPresenter() {
        return new WiMi.Pages.New.Presenter(
            WiMi.Pages.New.createView(),
            WiMi.Pages.New.createClient());
    }

    function createView() {
        var view = new WiMi.Pages.New.View();
        view._txtTitle = new Peper.InputText('txtTitle');
        view._txtBody = new Peper.InputText('txtBody');
        view._btnCreate = new Peper.Button('btnCreate');
        view._btnClose = new Peper.Button('btnClose');
        view._lblError = new Peper.Label('lblError');
        view._lblInformation = new Peper.Label('lblInformation');
        return view;
    }

    function createClient() {
        return new WiMi.Pages.New.Client(new WiMi.Http());
    }
    
    WiMi.namespace("Pages.New");
    WiMi.Pages.New.Presenter = Presenter;
    WiMi.Pages.New.createPresenter = createPresenter;
    WiMi.Pages.New.View = View;
    WiMi.Pages.New.createView = createView;
    WiMi.Pages.New.Client = Client;
    WiMi.Pages.New.createClient = createClient;
})(WiMi || {})