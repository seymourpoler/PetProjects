function Sum(augend, addend){
    var self = this;
    var allMoney = [augend, addend];

    self.reduce = function(bank, to){
        var initValue = 0;
        var amount = allMoney.reduce(reduceAllMoney, initValue);
        return new Money(amount, to);

        function reduceAllMoney(total, current){
            return total + current.reduce(bank, to).getAmount();
        };
    };

    self.plus = function(money){
        allMoney.push(money);
        return this;
    };

    self.times = function(numberOfTimes){
        return new Sum(
            augend.times(numberOfTimes),
            addend.times(numberOfTimes));
    };
}