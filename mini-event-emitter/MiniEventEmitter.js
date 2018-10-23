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
				handler();
			});
		}
	};
	
	self.unSubscribe = function(event){
		events[event] = [];
	};
}


if( typeof module !== "undefined" && ('exports' in module)){
	module.exports = MiniEventEmitter;
}
