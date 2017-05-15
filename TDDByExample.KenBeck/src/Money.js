function Money(amount, currency){
    var self = this;
    var curretAmount = amount;

    self.franc = function(numberOfFrancs){
        return new Franc(numberOfFrancs, "CHF");
    };

    self.dollar = function(){
        return new Money(curretAmount, "USD");
    };

    self.getAmount = function(){
        return curretAmount;
    };

    self.times = function(numberOfTimes){
        return new Money(curretAmount * numberOfTimes, currency);
    };

    self.equals = function(francs){
        return curretAmount == francs.getAmount() &&
         currency == francs.currency();
    };

    self.currency = function(){
        return currency;
    };

    self.plus = function(added){
        var currencySumed = curretAmount + added.getAmount()
        return new Money(currencySumed, currency);
    };
    
    self.reduce = function(bank, to){
        var rate = bank.rate(currency, to);
        return new Money(curretAmount/rate, to);
    };
}

function MoneyFactory(){
    var self = this;

    self.dollar = function(amount){
        return new Money(amount, "USD");
    };

    self.franc = function(amount){
        return new Money(amount, "CHF");
    };
}
