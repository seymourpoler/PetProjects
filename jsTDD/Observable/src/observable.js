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
}