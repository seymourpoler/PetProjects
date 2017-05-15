function Dollar(amount, currency){
    var self = this;
    var curretAmount = amount;

    self.getAmount = function(){
        return curretAmount;
    };

    self.times = function(numberOfTimes){
        return new Dollar(curretAmount * numberOfTimes, currency);
    };

    self.equals = function(dollars){
        return (dollars instanceof Dollar) &&
        curretAmount == dollars.getAmount() &&
        currency == dollars.currency();
    };

    self.currency = function(){
        return currency;
    };
}