describe("Controls", function () {
    
    describe("DIV Control", function () {
        var div = null;
        beforeEach(function() {
             div = new Div();
        });
        it("Simple div render", function(){
            expect(div.render()).toEqual('<div></div>');
        });
        it("div render with id", function(){
            div.id = 'divid';
            expect(div.render()).toEqual("<div id='divid'></div>");
        });
        it("div render with id style & class", function(){
            div.id = 'divid';
            div.style = 'style';
            div.cssClass = 'class';
            expect(div.render()).toEqual("<div id='divid' class='class' style='style'></div>");
        });
        it("div disabled", function(){
            div.id = 'divid';
            div.disabled = true;
            expect(div.render()).toEqual("<div id='divid' disabled='disabled'></div>");
        });
        it("div add css class", function(){
            div.id = 'divid';
            div.cssClass = 'classOne';
            div.addCssClass('classTwo');
            expect(div.render()).toEqual("<div id='divid' class='classOne classTwo'></div>");
        });
        it("div render with visible style", function(){
            div.id = 'divid';
            div.style = 'style;';
            div.cssClass = 'class';
            div.visible = true;
            expect(div.render()).toEqual("<div id='divid' class='class' style='style;visibility:visible;'></div>");
        });
        it("div render with a two controls", function(){
            var label = new Label();
            label.text = "Label";
            var textBox = new TextBox();
            textBox.disabled = true;
            div.addControl(label);
            div.addControl(textBox);
            expect(div.render()).toEqual("<div><label>Label</label><input type='text' disabled='disabled'></input></div>");
        });
    });

    describe("Span Control", function () {
        var span = null;
        beforeEach(function() {
             span = new Span();
        });
        
        it("Simple span render", function(){
            expect(span.render()).toEqual('<span></span>');
        });
        it("span render with id", function(){
            span.id = 'spannpsa';
            expect(span.render()).toEqual("<span id='spannpsa'></span>");
        });
        it("span render with id style & class", function(){
            span.id = 'spanid';
            span.style = 'style';
            span.cssClass = 'class';
            expect(span.render()).toEqual("<span id='spanid' class='class' style='style'></span>");
        });
        it("span enabled", function(){
            span.disabled = false;
            expect(span.render()).toEqual("<span></span>");
        });
        it("span remove css class", function(){
            span.id = 'spanId';
            span.cssClass = 'classOne classTwo classThree classFour';
            span.removeCssClass('classTwo');
            expect(span.render()).toEqual("<span id='spanId' class='classOne classThree classFour'></span>");
        });
        it("span with not visible style", function(){
            span.disabled = false;
            span.visible = false;
            expect(span.render()).toEqual("<span style='visibility:hidden;'></span>");
        });
        it("span remove css class with a text box", function(){
            span.id = 'spanId';
            span.cssClass = 'classOne classTwo classThree classFour';
            var textBox = new TextBox();
            textBox.cssClass = 'classOne classFour';
            textBox.disabled = true;
            textBox.visible = false;
            span.addControl(textBox);
            expect(span.render()).toEqual("<span id='spanId' class='classOne classTwo classThree classFour'><input type='text' class='classOne classFour' style='visibility:hidden;' disabled='disabled'></input></span>");
        });
    });
});
