(function (WiMi) {
    function Presenter(view, client) {
        var self = this;
        client.find(successHandler, errorHandler);

        function successHandler(pages) {
            view.showPages(pages);
        }
        function errorHandler() {
            throw 'not implemented';
        }
    }

    function View() {
        var self = this;

        self.showPages = function (pages) {
            throw 'not implemented';
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