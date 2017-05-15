describe("Franc", function(){
    
    it("returns amount", function(){
        var franc = new Franc(3, "CHF");

        var result = franc.getAmount();

        expect(3).toBe(result);
    });

    it("returns some number of times per amounts", function(){
        var twoFrancs = new Franc(2, "CHF");
        
        expect(twoFrancs.times(3).equals(new Franc(6, "CHF"))).toBeTruthy();
        expect(twoFrancs.times(4).equals(new Franc(8, "CHF"))).toBeTruthy();
    });

    describe("when equals is requested", function(){

        it("returns false if there is another class", function(){
            var oneFranc = new Franc(1, "CHF");

            expect(oneFranc.equals(new Dollar(3, "USD"))).toBeFalsy();
        });

        it("returns true if two francs are equals", function(){
            var fiveFrancsOne = new Dollar(5, "USD");
            var fiveFrancsTwo = new Dollar(5, "USD");

            var result = fiveFrancsOne.equals(fiveFrancsTwo);

            expect(true).toBe(result);
        });

        it("returns false if two franc are different", function(){
            var fiveFrancsOne = new Dollar(5, "USD");
            var fiveFrancsTwo = new Dollar(3, "USD");

            var result = fiveFrancsOne.equals(fiveFrancsTwo);

            expect(false).toBe(result);
        });
    });

    it("returns currency", function(){
        var fiveFrancs = new Franc(5, "CHF")

        expect(fiveFrancs.currency()).toBe("CHF");
    });
});