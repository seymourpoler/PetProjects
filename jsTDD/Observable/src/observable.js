function Observable(){
    var self = this;
    self.observers = [];

    self.addObserver = function(observer){
        if( typeof observer != "function"){
            throw new Error("observer is not function");
        }
        self.observers.push(observer);
    };

    self.hasObserver = function(observer){
        const FIRST_OBSERVER_POSITION = 0;
        return self.observers.indexOf(observer) >= FIRST_OBSERVER_POSITION;
    };

    self.notifyObservers = function(){
        for(var position = 0; position < self.observers.length; position++){
            try{
                //self.observers[position]();
                self.observers[position].apply(self, arguments);
            }
            catch (e){
                console.log('error notifying to observers: ', e);
            }
        }
    };
}