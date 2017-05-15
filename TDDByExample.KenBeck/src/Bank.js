function Bank(){
    var self = this;
    var rates = [{from: "USD", to: "USD", rate: 1},
                 {from: "CHF", to: "CHF", rate: 1}];

    self.reduce = function(sum, to){
        return sum.reduce(self, to);
    };

    self.addRate = function(from, to, rate){
        rates.push({from: from, to: to, rate: rate});
    };

    self.rate  = function(from, to){
        var ratesFiltered = rates.filter(function(rate){
            return rate.from == from &&
                    rate.to == to;
        });
        var selectedRate = ratesFiltered[0];
        return selectedRate.rate;
    };
}