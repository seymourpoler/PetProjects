function Presenter(view, client) {
    view.subcribeToTodoSavingRequested(todoSavingRequestedHandler);

    function todoSavingRequestedHandler() {
        var request = buildRequest();

        client.save(request, successHandler, errorHandler);

        function buildRequest() {
            var title = view.getTitle();
            var description = view.getDescription();
            return {
                'title': title,
                'description': description
            };
        }

        function successHandler() {
            view.showMessage();
        }

        function errorHandler(errors) {
            for (var position = 0; position < errors.length; position++) {
                view.showErrorMessageFor(errors[position].FieldId, errors[position].ErrorType);
            }
        }
    }
}

function View() {
    var self = this;

    var messages = {
        'ServerInternalError': 'Error interno en el servidor.',
        'Required': 'campo obligatio',
        'WrongLength': 'logitud incorrecta del campo'
    };

    var fields = {
        'title': 'Title',
        'description': 'Description',
    };

    self.getTitle = function () {
        return $('#txtTitle').val();
    };

    self.getDescription = function () {
        return $('#txtDescription').val();
    };

    self.subcribeToTodoSavingRequested = function (handler) {
        $('#btnSave').on('click', function () {
            handler();
        });
    };

    self.showMessage = function () {
        $('#lblMessage').text('created successfully');
        $('#lblMessage').show();
    };

    self.showErrorMessage = function (errorCode) {
        $('#lblErrorMessage').text(messages[errorCode]);
        $('#lblErrorMessage').show();
    };

    self.showErrorMessageFor = function(fieldId, errorCode) {
        $('#lblErrorMessage').text(fields[fieldId] + ' ' + messages[errorCode]);
        $('#lblErrorMessage').show();
    };
}

function Client() {
    var self = this;

    self.save = function (request, successHandler, errorHandler) {
        $.ajax({
            type: 'POST',
            url: '/api/todos',
            dataType: 'json',
            data: request
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