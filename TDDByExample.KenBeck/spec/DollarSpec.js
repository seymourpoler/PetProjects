describe("Dollar", function(){
    
    it("returns amount", function(){
        var dollar = new Dollar(3, "USD");

        var result = dollar.getAmount();

        expect(3).toBe(result);
    });

    it("returns some number of times per amounts", function(){
        var twoDollars = new Dollar(2, "USD");

        expect(twoDollars.times(3).equals(new Dollar(6, "USD"))).toBeTruthy();
        expect(twoDollars.times(4).equals(new Dollar(8, "USD"))).toBeTruthy();
    });

    describe("when equals is requested", function(){
        it("returns false if there is another class", function(){
            var oneDollar = new Dollar(1, "USD");

            expect(oneDollar.equals(new Franc(3))).toBeFalsy();
        });

        it("returns true if two dollars are equals", function(){
            var fiveDollarsOne = new Dollar(5, "USD");
            var fiveDollarsTwo = new Dollar(5, "USD");

            var result = fiveDollarsOne.equals(fiveDollarsTwo);

            expect(true).toBe(result);
        });

        it("returns false if two dollars are different", function(){
            var fiveDollarsOne = new Dollar(5, "USD");
            var fiveDollarsTwo = new Dollar(3, "USD");

            var result = fiveDollarsOne.equals(fiveDollarsTwo);

            expect(false).toBe(result);
        });
    });

    it("returns currency", function(){
        var fiveDollars = new Dollar(5, "USD");

        expect(fiveDollars.currency()).toBe("USD");
    });
});