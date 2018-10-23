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
				const handlerArguments = [].slice.call(arguments, 1);
				handler(handlerArguments);
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
	
	self.mixin = function(objectRequest){
		let result = Object.assign({}, objectRequest);
		var properties	= ['subscribe', 'emit', 'unSubscribe'];
		properties.forEach(property => {
			result[property] = self[property];
		});
		
		// for(var i = 0; i < props.length; i ++){
		// if( typeof destObject === 'function' ){
			// destObject.prototype[props[i]]	= MicroEvent.prototype[props[i]];
		// }else{
			// destObject[props[i]] = MicroEvent.prototype[props[i]];
		// }
	
		return result;
	};
}


if( typeof module !== "undefined" && ('exports' in module)){
	module.exports = MiniEventEmitter;
}
