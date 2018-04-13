function Observable(){
    var self = this;
    self.observers = [];

    self.addObserver = function(observer){
        self.observers.push(observer);
    };
}