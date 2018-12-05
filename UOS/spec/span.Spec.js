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