(function (WiMi) {
    function IndexPresenter(view, client) {
        let self = this;

        self.create = function(){}
    }

    function IndexView(view, client) {
        let self = this;

        self.showErrors = function(errors){
            throw 'not implemented';
        };
    }

    function IndexClient(view, client) {
        let self = this;

        self.save = function(page, successHandler, errorHandler){
            throw 'not implemented';
        };
    }

    function createIndexPresenter() {
    }

    function createIndexView(){
    }

    function createIndexClient(){

    }
    
    WiMi.namespace("Pages.Index");
    WiMi.Pages.Index.IndexPresenter = IndexPresenter;
    WiMi.Pages.Index.createIndexPresenter = createIndexPresenter;
    WiMi.Pages.Index.IndexView = IndexView;
    WiMi.Pages.Index.createIndexView = createIndexView;
    WiMi.Pages.Index.IndexClient = IndexClient;
    WiMi.Pages.Index.createIndexClient = createIndexClient;
})(WiMi || {})