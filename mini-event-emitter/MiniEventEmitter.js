function MiniEventEmitter (){
	let self = this;
	let events = [];
	
	self.subscribe = function(event, handler){
		if(!events[event]){
			events[event] = []
		}
		events[event].push(handler);
	};
	
	self.emit = function(event){
		const handlers = events[event];
		if(handlers){
			handlers.forEach(handler => {
				handler(arguments.slice(1));
			});
		}
	};
	
	self.unSubscribe = function(event, handler){
		if(!handler){
			events[event] = [];
			return;
		}
		events[event] = events[event].filter(aHandler => aHandler.toString() !== handler.toString())
	};
}


if( typeof module !== "undefined" && ('exports' in module)){
	module.exports = MiniEventEmitter;
}
