describe("Sum", function(){
    var bank;
    var moneyFactory;

    beforeEach(function(){
        bank = new Bank();
        moneyFactory = new MoneyFactory();
    });

    it("Rates addition", function(){
        var fiveDollars = moneyFactory.dollar(5);
        var tenFrancs = moneyFactory.franc(10);
        bank.addRate("CHF", "USD", 2);
        var sum = new Sum(fiveDollars, tenFrancs);

        var result = sum.reduce(bank, "USD");

        expect(moneyFactory.dollar(10).equals(result)).toBeTruthy();
    });

    it("sum plus money", function(){
       var fiveDollars = moneyFactory.dollar(5);
        var tenFrancs = moneyFactory.franc(10);
        bank.addRate("CHF", "USD", 2);
        var sum = new Sum(fiveDollars, tenFrancs).plus(fiveDollars);

        var result = sum.reduce(bank, "USD");

        expect(moneyFactory.dollar(15).equals(result)).toBeTruthy();

    });

    it("sum times", function(){
        var fiveDollars = moneyFactory.dollar(5);
        var tenFrancs = moneyFactory.franc(10);
        bank.addRate("CHF", "USD", 2);
        var sum = new Sum(fiveDollars, tenFrancs).times(2);

        var result = sum.reduce(bank, "USD");

        expect(moneyFactory.dollar(20).equals(result)).toBeTruthy();
    });
});