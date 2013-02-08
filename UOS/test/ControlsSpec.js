describe("Controls", function () {
    
    describe("DIV Control", function () {
        it("Simple div render", function(){
            var div = new Div();
            expect(div.render()).toEqual('<div></div>');
        });
        it("div render with id", function(){
            var div =  new Div();
            div.id = 'divid';
            expect(div.render()).toEqual("<div id='divid'></div>");
        });
        

    });

    describe("Sapn Control", function () {
        it("Simple span render", function(){
            var span = new Span();
            expect(span.render()).toEqual('<span></span>');
        });
        it("span render with id", function(){
            var span =  new Span();
            span.id = 'spannpsa';
            expect(span.render()).toEqual("<span id='spannpsa'></span>");
        });
        

    });
});
