function Presenter(view, client) {
    view.subscribeToTodoDeletingRequested(todoDeletingRequestedHandler);
    function todoDeletingRequestedHandler(id){
        client.delete(id, successHandler, errorhandler);
        function successHandler() {
            view.showMessage('ok');}
        function errorhandler(){}
    }
}

function View() {
    var self = this;
    var messages = {
        'ServerInternalError': 'Error interno en el servidor',
        'ok': 'removed successfully',
        'TodoNotFound': 'todo not found'
    };


    self.subscribeToTodoDeletingRequested = function (handler) {
        $('.remove').on('click', function () {
            var id = $(this).closest("tr").find(".id").text();
            handler(id);
        });
    };

    self.showMessage = function (messageCode) {
        $('#lblMessage').text(messages[messageCode]);
        $('#lblMessage').show();
    };
}

function Client() {
    var self = this;

    self.delete = function (id) {
        $.ajax({
            type: 'DELETE',
            url: '/api/todos/' + id,
            dataType: 'json'
        }).always(function (response) {
            if (response.status === 200) {
                successHandler();
                return;
            }
            if (response.status === 500) {
                errorHandler('ServerInternalError');
                return;
            }
            errorHandler(response.responseJSON);
        });
    };
}

function createPresenter() {
    return new Presenter(
        new View(),
    new Client());
}