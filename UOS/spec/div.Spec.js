describe('Div control', function(){
    it("Simple div render", function(){
        let div = new Div();
        expect(div.render()).toEqual('<div></div>');
    });

    it("div render with id", function(){
        let div = new Div({id: 'div-id'});
        expect(div.render()).toEqual("<div id='div-id'></div>");
    });
});