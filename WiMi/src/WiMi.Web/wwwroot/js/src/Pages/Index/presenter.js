(function (WiMi) {
    function Presenter(view, client) {
        var self = this;
        view.subscribeToEditionPageRequested(editionPageRequestedHandler);
        view.subscribeToCreationNewPageRequested(creationNewPageRequestedHandler);
        function editionPageRequestedHandler(pageId) {
            view.redirectToEditionPage(pageId);
        }
        function creationNewPageRequestedHandler() {
            view.redirectToCreationNewPage();
        }

        findPages();
        function findPages() {
            view.showSpinner();
            client.find(successHandler, errorHandler);

            function successHandler(pages) {
                view.hideSpinner();
                view.showPages(pages);
            }
            function errorHandler(error) {
                view.hideSpinner();
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
            self._redirector.redirect('/pages/new/' + pageId);
        };

        self.redirectToCreationNewPage = function () {
            self._redirector.redirect('/pages/new');
            //window.location.href = '/pages/new';
        };

        self.showPages = function (pages) {
            self._lstPage.clear();
            for (let index = 0; index < pages.length; index++) {
                self._lstPage.addItem({ id: pages[index].id, name: pages[index].title });
            }
        };

        self.showError = function () {
            self._lblError.showText('there is an error');
        };

        self.showSpinner = function () {
            self._spinner.show();
        };

        self.hideSpinner = function () {
            self._spinner.hide();
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
        view._lstPage = new Peper.List('lstPage');
        view._redirector = new Peper.Redirector();
        view._spinner = new Peper.Panel('spinner');
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

})(WiMi || {});