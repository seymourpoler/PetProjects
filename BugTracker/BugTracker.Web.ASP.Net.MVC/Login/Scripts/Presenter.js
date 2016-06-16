
function Presenter(view, client, redirector){
	view.subscribeToLoginRequested(loginRequestedHanler);

	function loginRequestedHanler(credentials){
		client.login(credentials, successHandler, errorHandler);

		function successHandler(){
			redirector.redirect("/bugs");
		}

		function errorHandler(response){
			view.showErrorMessage(response.errorCode);
		}
	}
}

function View(){
	var errorMessages = {
		'internalServerError': 'Internal server error.',
		'badRequest': 'credentials are wrong.'
	};
	var self = this;
	var txtLogin = new delta.TextBox('txtLogin');
	var txtPassword = new delta.TextBox('txtPassword');
	var btnOk = new delta.Button('btnOk');
	var lblErrorMessage = new delta.Label('lblErrorMessage');


	var loginRequestedHanler = function(){};

	self.subscribeToLoginRequested = function(handler){
		btnOk.onClick(function(){
			handler({
				'login': txtLogin.getText(),
				'password': txtPassword.getText()
			});	
		});
	};

	self.showErrorMessage = function(errorCode){
		lblErrorMessage.show();
		lblErrorMessage.setText(errorMessages[errorCode]);
	};
}

function Client(){
	var self = this;
	var url = 'api/login';
	self.login = function(credentials, successHandler, errorHandler){
	$.post(url, credentials)
		.done(function(data){
			successHandler(data);
		})
		.fail(function(response){
			errorHandler(response.responseJSON);
		});
	};
}

function createPresenter(){
	return new Presenter(
		createView(),
		createClient(),
		new delta.Redirector()
	);
}

function createView(){
	return new View();
}

function createClient(){
	return new Client();
}
