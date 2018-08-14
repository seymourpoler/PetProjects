(function (WiMi) {
    function Presenter(view, client) {
        var self = this;
        view.subscribeToEditionPageRequested(editionPageRequestedHandler);
        view.subscribeToCreationNewPageRequested(creationNewPageRequestedHandler);
        findPages();
        function editionPageRequestedHandler(pageId){
            view.redirectToEditionPage(pageId);
        }
        function creationNewPageRequestedHandler() {
            view.redirectToCreationNewPage();
        }

        function findPages() {
            client.find(successHandler, errorHandler);

            function successHandler(pages) {
                view.showPages(pages);
            }
            function errorHandler(error) {
                view.showError();
            }
        }
    }

    function View() {
        var self = this;
        var editionPageRequestedHandler = function () { };

        self.subscribeToEditionPageRequested = function (handler) {
            editionPageRequestedHandler = handler;
        };

        self.subscribeToCreationNewPageRequested = function (handler) {
            creationNewPageRequestedHandler = handler;
            self._btnNew.on('click', creationNewPageRequestedHandler);
        };

        self.redirectToEditionPage = function (pageId) {
            throw 'not implementing';
        };

        self.redirectToCreationNewPage = function () {
            self._redirector.redirect('/pages/new');
            //window.location.href = '/pages/new';
        };

        self.showPages = function (pages) {
            throw 'not implemented';
        };

        self.showError = function () {
            self._lblError.showText('there is an error');
        };
    }

    function Client(http) {
        var self = this;

        self.find = function (successHandler, errorHandler) {
            http.get('/api/pages', successHandler, errorHandler);
        };
    }

    function createPresenter() {
        return new WiMi.Pages.Index.Presenter(
            WiMi.Pages.Index.createView(),
            WiMi.Pages.Index.createClient());
    }

    function createView() {
        var view = new WiMi.Pages.Index.View();
        view._btnNew = new Peper.Button('btnNew');
        view._lblError = new Peper.Label('lblError');
        view._redirector = new Peper.Redirector();
        return view;
    }

    function createClient() {
        return new WiMi.Pages.Index.Client(new WiMi.Http());
    }

    WiMi.namespace("Pages.Index");
    WiMi.Pages.Index.Presenter = Presenter;
    WiMi.Pages.Index.createPresenter = createPresenter;
    WiMi.Pages.Index.View = View;
    WiMi.Pages.Index.createView = createView;
    WiMi.Pages.Index.Client = Client;
    WiMi.Pages.Index.createClient = createClient;

})(WiMi || {})