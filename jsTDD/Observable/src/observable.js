function Observable(){
    var self = this;
    self.observers = [];

    self.addObserver = function(observer){
        self.observers.push(observer);
    };

    self.hasObserver = function(observer){
        const FIRST_OBSERVER_POSITION = 0;
        return self.observers.indexOf(observer) >= FIRST_OBSERVER_POSITION;
    };

    self.notifyObservers = function(){
        for(var position = 0; position < self.observers.length; position++){
            self.observers[position]();
        }
    };
}