function Observable(){
    var self = this;
    self.observers = [];

    self.addObserver = function(observer){
        self.observers.push(observer);
    };

    self.hasObserver = function(observer){
        for(var position = 0; position < self.observers.length; position++){
            if(self.observers[position] == observer){
                return true;
            }
        }
        return false;
    };
}