function Presenter(view, client) {
    var self = this;

    view.subscribeToLoginRequested(loginRequestedHandler);
    function loginRequestedHandler() {
        client.login({
            email: view.getEmail(),
            password: view.getPassword()
        }, successHandler, errorHandler);
        function successHandler() {
            window.location.href = "/todos/index";}
        function errorHandler() {
            $('#lblMessage').text('error in login review credentials');
        }
    };
}

function View() {
    var self = this;

    self.subscribeToLoginRequested = function (handler) {
        $('#btnLogin').on('click', function () {
            handler();
        });
    };

    self.getEmail = function () {
        return $('#txtEmail').val();
    };

    self.getPassword = function () {
        return $('#txtPassword').val();
    };
}

function Client() {
    var self = this;

    self.login = function (loginRequest, successHandler, errorHandler) {
        $.ajax({
            type: 'POST',
            url: '/api/login',
            dataType: 'json',
            data: loginRequest
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

function createPresenter(){
    return new Presenter(
        new View(),
        new Client());
}