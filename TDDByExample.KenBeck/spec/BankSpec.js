describe("Bank", function(){
    var bank;
    var moneyFactory;
    
    beforeEach(function(){
        bank = new Bank();
        moneyFactory = new MoneyFactory();
    });

    it("gets rates", function(){
        bank.addRate("CHF", "USD", 2);

        var result = bank.rate("CHF", "USD");

        expect(result).toBe(2);
    });

    it("reduces a sumatory", function(){
        var fiveDollars = moneyFactory.dollar(5);
        var tenFrancs = moneyFactory.franc(10);
        bank.addRate("CHF", "USD", 2);
        var sum = new Sum(fiveDollars, tenFrancs);

        var result = bank.reduce(sum, "USD");

        expect(moneyFactory.dollar(10).equals(result)).toBeTruthy();
    });

});