function Observable(){
    var self = this;
    self.observers = [];

    self.addObserver = function(observer){
        self.observers.push(observer);
    };

    self.hasObserver = function(observer){
        return self.observers.indexOf(observer) >= 0;
    };
}