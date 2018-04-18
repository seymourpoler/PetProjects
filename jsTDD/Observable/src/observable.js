function Observable(){
    var self = this;
    self.observers = [];

    self.addObserver = function(event, handler){
        if(!self.observers[event]){
            self.observers[event] = [];
        }
        if(typeof handler != 'function'){
            throw new TypeError("observer is nor a function");
        }
        self.observers[event].push(handler);
    };

    self.hasObserver = function(event, observer){
        const FIRST_OBSERVER_POSITION = 0;
        var observersByEvent = self.observers[event];
        if(!observersByEvent){return false;}
        return observersByEvent.indexOf(observer) >= FIRST_OBSERVER_POSITION;
    };

    self.notifyObservers = function(event){
        var args = Array.prototype.slice.call(arguments, 1);
        var obseversByEvent = self.observers[event];
        if(!obseversByEvent){return;}
        for(var position = 0; position < obseversByEvent.length; position++){
            try{
                //self.observers[position]();
                obseversByEvent[position].apply(self, args);
            }
            catch (e){
                console.log('error notifying to observers: ', e);
            }
        }
    };
}