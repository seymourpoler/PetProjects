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
        it("div render with id style & class", function(){
            var div =  new Div();
            div.id = 'divid';
            div.style = 'style';
            div.cssClass = 'class';
            expect(div.render()).toEqual("<div id='divid' class='class' style='style'></div>");
        });
        it("div disabled", function(){
            var div =  new Div();
            div.id = 'divid';
            div.disabled = true;
            expect(div.render()).toEqual("<div id='divid' disabled='disabled'></div>");
        });
        it("div add css class", function(){
            var div =  new Div();
            div.id = 'divid';
            div.cssClass = 'classOne';
            div.addCssClass('classTwo');
            expect(div.render()).toEqual("<div id='divid' class='classOne classTwo'></div>");
        });
    });

    describe("Span Control", function () {
        it("Simple span render", function(){
            var span = new Span();
            expect(span.render()).toEqual('<span></span>');
        });
        it("span render with id", function(){
            var span =  new Span();
            span.id = 'spannpsa';
            expect(span.render()).toEqual("<span id='spannpsa'></span>");
        });
        it("span render with id style & class", function(){
            var span =  new Span();
            span.id = 'spanid';
            span.style = 'style';
            span.cssClass = 'class';
            expect(span.render()).toEqual("<span id='spanid' class='class' style='style'></span>");
        });
        it("span enabled", function(){
            var span =  new Span();
            span.disabled = false;
            expect(span.render()).toEqual("<span></span>");
        });

        it("span remove css class", function(){
            var span =  new Span();
            span.id = 'spanId';
            span.cssClass = 'classOne classTwo classThree classFour';
            span.removeCssClass('classTwo');
            expect(span.render()).toEqual("<span id='spanId' class='classOne classThree classFour'></span>");
        });
    });
});
