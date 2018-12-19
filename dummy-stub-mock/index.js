function Sut(client){
	var self = this;

	self.getValue = function(){
		return client.getValue();
	};

	self.collaborator_needed_method = function(){
		client.doSomeThingVeryImportant();
	};
}