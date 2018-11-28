describe('label', function(){
    var control = null;
        beforeEach(function() {
             control = new Label();
        });
        it("Simple label render", function(){
            expect(control.render()).toEqual('<label></label>');
        });
});