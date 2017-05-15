describe("Money", function(){
    var bank;
    var moneyFactory;
    
    beforeEach(function(){
        bank = new Bank();
        bank.addRate("CHF", "USD", 2);
        moneyFactory = new MoneyFactory();
    });

    it("creates francs", function(){
        var fiveFrancs = new Money(5, "CHF");
        var result = moneyFactory.franc(10);

        expect(fiveFrancs.times(2).equals(result)).toBeTruthy();
    });

    it("creates dollars", function(){
        var fiveDollars = new Money(5, "USD");
        var result = new MoneyFactory().dollar(10);

        expect(fiveDollars.times(2).equals(result)).toBeTruthy();
    });

    it("returns USD currency", function(){
        var fiveDollars = new Dollar(5, "USD");

        expect(moneyFactory.dollar(5).currency()).toBe("USD");
    });

    it("returns CHF currency", function(){
        var fiveFrancs = new Franc(5, "CHF");

        expect(moneyFactory.franc(5).currency()).toBe("CHF");
    });

    it("returns simple addition in the same currency", function(){
        var result = moneyFactory.dollar(5).plus(moneyFactory.dollar(5));

        expect(moneyFactory.dollar(10).equals(result)).toBeTruthy();
    });

    it("reduces money in different currency", function(){
        var twoFrancs = moneyFactory.franc(2);
        bank.addRate("CHF", "USD", 2);

        var result = twoFrancs.reduce(bank, "USD");

        expect(moneyFactory.dollar(1).equals(result)).toBeTruthy();
    });
});