describe("Span Control", function () {
    
    it("Simple span render", function(){
        let span = UOS.Controls.createSpan();

        expect(span.render()).toEqual('<span></span>');
    });

    it("span render with id", function(){
        let span = UOS.Controls.createSpan({id: 'spannpsa'});
        expect(span.render()).toEqual("<span id='spannpsa'></span>");
    });

    it("span render with id style & class", function(){
        let span = UOS.Controls.createSpan({id: 'span-id', style: 'style', cssClass: 'class'});
        
        const result = span.render();
        
        expect(span.render()).toEqual("<span id='span-id' class='class' style='style'></span>");
    });

    it("span remove css class", function(){
        let span = UOS.Controls.createSpan({cssClass: 'classOne classTwo classThree classFour'});
        span.removeCssClass('classTwo');
        
        const result = span.render();
        
        expect(result).not.toContain("classTwo'");
    });

    it("span disabled", function(){
		let span = UOS.Controls.createSpan({id: 'span-id'});
		span.disable();
		
		const result = span.render();
		
        expect(result).toEqual("<span id='span-id' disabled></span>");
    });
	
	it("span enable", function(){
		let span = UOS.Controls.createSpan({id: 'span-id'});
		span.disable();
		span.enable();
		
		const result = span.render();
		
        expect(result).toEqual("<span id='span-id'></span>");
    });

    it("hides", function(){
        let span = UOS.Controls.createSpan({id: 'span-id'});
        span.hide();
        
        const result =  span.render();

        expect(span.render()).toEqual("<span id='span-id' style='display:none;'></span>");
    });
	
	it("shows", function(){
        let span = UOS.Controls.createSpan({id: 'span-id'});
        span.show();
        
        const result =  span.render();

        expect(result).toEqual("<span id='span-id' style='display:block;'></span>");
    });

    it("span with not visible style", function(){
		let span = UOS.Controls.createSpan({id: 'span-id'});
		span.enable();
        span.hide();

		const result = span.render();
		
        expect(result).toEqual("<span id='span-id' style='display:none;'></span>");
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