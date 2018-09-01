(function (WiMi) {

    function Presenter(id, view, client) {
        var self = this;

        console.log(id);
    }
    function View() {
        var self = this;
    }

    function Client(http) {
        var self = this;
    }

    function createPresenter() {
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