function MiniEventEmitter (){
	let self = this;
	let eventAndHandlers = [];
	
	self.subscribe = function(event, handler){
		eventAndHandlers.push({event: event, handler: handler});
	};
	
	self.emit = function(event){
		eventAndHandlers.forEach(function(eventHandler){
			if(eventHandler.event === event){
				eventHandler.handler();
			}
		});
	};
	
	self.unSubscribe = function(){
		throw 'not implemented';
	};
}


if( typeof module !== "undefined" && ('exports' in module)){
	module.exports = MiniEventEmitter;
}
