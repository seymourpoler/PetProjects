function Presenter(view, client){
	getBugs();
	view.subscribeToCreationNewBugRequested(creationNewBugRequestedHandler)
	view.subscribeToCancelationCreationNewBugRequested(cancelationCreationNewBugRequestedHandler)

	function getBugs(){
		view.hideErrorMessage();
		client.getBugs(successHandler, errorHandler);

		function successHandler(bugs){
			view.showBugs(bugs);
			view.subscribeToDeletetingBugRequested(deletetingBugRequestedhandler);
		}

		function errorHandler(response){
			view.showErrorMessage(response.errorCode);
		}
	}

	function creationNewBugRequestedHandler(newBugRequest){
		view.hideErrorMessage();
		client.saveNewBug(newBugRequest, successHandler, errorHandler);

		function successHandler(){
			view.clearBugName();
			view.clearBugDescription();
			getBugs();
		}

		function errorHandler(response){
			view.showErrorMessage(response.errorCode);
		}
	}

	function cancelationCreationNewBugRequestedHandler(){
		view.clearBugName();
		view.clearBugDescription();
	}

	function deletetingBugRequestedhandler(idBug){
		view.hideErrorMessage();
		client.deleteBug(idBug, successHandler, errorHandler);

		function successHandler(){
			getBugs();
		}

		function errorHandler(response){
			view.showErrorMessage(response.errorCode);
		}
	}
}

function View(){
	var errorMessages = {
		'internalServerError': 'Internal server error.',
		'bugNameIsRequired': 'Name field is required',
		'idBugIsRequired': 'Bug id is required',
		'bugDoesNotBelongToCurrentUser': 'This bug does not belong to current user '
	};
	var self = this;
	var listOfBugs = new delta.List('lstBugs');
	var lblErrorMessage = new delta.Label('lblErrorMessage');
	var newBugPanel = new delta.Panel('newBugPanel');
	var btnCreateNewBug = new delta.Button('btnCreateNewBug');
	var btnCancelCreationNewBug = new delta.Button('btnCancelCreationNewBug');
	var txtNewBugName = new delta.TextBox('txtNewBugName');
	var txtNewBugDescription = new delta.TextBox('txtNewBugDescription');

	self.subscribeToCreationNewBugRequested = function(handler){
		btnCreateNewBug.onClick(function(){
			handler({
				name: txtNewBugName.getText(), 
				description: txtNewBugDescription.getText()});
		});
	};

	self.subscribeToCancelationCreationNewBugRequested = function(handler){
		btnCancelCreationNewBug.onClick(function(){
			handler();
		});
	};

	self.subscribeToDeletetingBugRequested = function(handler){
		$('.remove').click(function(){
	      handler($(this)[0].id);
	    });
	};

	self.showBugs = function(bugs){
		listOfBugs.clear();
		for(var position=0; position<bugs.length; position++){
			listOfBugs.addHtmlItem("<li id='" + bugs[position].Id + "'>" + bugs[position].Name + " <a id='" + bugs[position].Id + "' class='remove'>X</a></li>");
		}
	};

	self.showErrorMessage = function(errorMessage){
		lblErrorMessage.show();
		lblErrorMessage.setText(errorMessages[errorCode]);
	};

	self.hideErrorMessage = function(){
		lblErrorMessage.setText('');
		lblErrorMessage.hide();
	};

	self.clearBugName = function(){
		txtNewBugName.clear();
	};
	self.clearBugDescription = function(){
		txtNewBugDescription.clear();
	};
}

function Client(){
	var self = this;
	var url = 'api/me/bugs';

	self.getBugs = function(successHandler, errorHandler){
		$.get(url)
			.done(function(data){
				successHandler(data);
			})
			.fail(function(response){
				errorHandler(response.responseJSON);
			});
	};

	self.saveNewBug = function(newBug, successHandler, errorHandler){
		$.post('api/me/create/bug', newBug)
			.done(function(data){
				successHandler(data);
			})
			.fail(function(response){
				errorHandler(response.responseJSON);
			});
	};

	self.deleteBug = function(idBug, successHandler, errorHandler){
		$.ajax({
	      url: 'api/me/remove/bug/' + idBug,
	      type: 'DELETE',
	      contentType: 'application/json'
	    })
	    .done(function() {
	      successHandler();
	    })
	    .fail(function(error) {
	      errorHandler(error);
	    });
	};
}

function createPresenter(){
	return new Presenter(
		createView(),
		createClient()
	);
}

function createView(){
	return new View();
}

function createClient(){
	return new Client();
}
