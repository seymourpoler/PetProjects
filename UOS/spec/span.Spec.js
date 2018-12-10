describe("Span Control", function () {
    var span = null;
    beforeEach(function() {
         span = new UOS.Span();
    });
    
    it("Simple span render", function(){
        span = new UOS.Span();

        expect(span.render()).toEqual('<span></span>');
    });

    it("span render with id", function(){
        span = new UOS.Span({id: 'spannpsa'});
        expect(span.render()).toEqual("<span id='spannpsa'></span>");
    });

    it("span render with id style & class", function(){
        span = new UOS.Span({id: 'span-id', style: 'style', cssClass: 'class'});
        
        const result = span.render();
        
        expect(span.render()).toEqual("<span id='span-id' style='style' class='class'></span>");
    });

    it("span remove css class", function(){
        span = new UOS.Span({cssClass: 'classOne classTwo classThree classFour'});
        span.removeCssClass('classTwo');
        
        const result = span.render();
        
        expect(result).not.toContain("classTwo'");
    });

    it("span disabled", function(){
		span = new UOS.Span({id: 'span-id'});
		span.disable();
		
		const result = span.render();
		
        expect(result).toEqual("<span id='span-id' disabled></span>");
    });
	
	it("span enable", function(){
		span = new UOS.Span({id: 'span-id'});
		span.disable();
		span.enable();
		
		const result = span.render();
		
        expect(result).toEqual("<span id='span-id'></span>");
    });

    it("hides", function(){
        span = new UOS.Span({id: 'span-id'});
        
        span.hide();
        
        const result =  span.render();

        expect(span.render()).toEqual("<span id='span-id' style='display:none;'></span>");
    });

    xit("span with not visible style", function(){
        span.disabled = false;
        span.visible = false;
        expect(span.render()).toEqual("<span style='visibility:hidden;'></span>");
    });

    xit("span remove css class with a text box", function(){
        span.id = 'spanId';
        span.cssClass = 'classOne classTwo classThree classFour';
        var textBox = new UOS.TextBox();
        textBox.cssClass = 'classOne classFour';
        textBox.disabled = true;
        textBox.visible = false;
        span.addControl(textBox);
        expect(span.render()).toEqual("<span id='spanId' class='classOne classTwo classThree classFour'><input type='text' class='classOne classFour' style='visibility:hidden;' disabled='disabled'></input></span>");
    });
});