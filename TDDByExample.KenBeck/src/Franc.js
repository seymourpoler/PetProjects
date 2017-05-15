function Franc(amount, currency){
    var self = this;
    var curretAmount = amount;

    self.getAmount = function(){
        return curretAmount;
    };

    self.times = function(numberOfTimes){
        return new Franc(curretAmount * numberOfTimes, currency);
    };

    self.equals = function(francs){
        return (francs instanceof Franc) &&
         curretAmount == francs.getAmount() &&
         currency == francs.currency();
    };

    self.currency = function(){
        return currency;
    };
}