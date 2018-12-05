describe('Div control', function(){
    var div = null;

    beforeEach(function() {
         div = new Div();
    });
    
    it("Simple div render", function(){
        expect(div.render()).toEqual('<div></div>');
    });
});