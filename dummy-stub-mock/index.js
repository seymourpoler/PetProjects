function Sut(client){
	var self = this;

	self.getValue = function(){
		return client.getValue();
	};
}