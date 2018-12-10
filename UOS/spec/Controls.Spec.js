describe("Controls", function () {
    describe("DIV Control", function () {
        var div = null;
		
        beforeEach(function() {
             div = new Control();
        });
		
        it("Simple div render", function(){
			let control = new UOS.Control({tag:'div'});
			
			const result = control.render();
			
            expect(result).toEqual('<div></div>');
        });
		
        xit("div render with id", function(){
            div.id = 'divid';
            expect(div.render()).toEqual("<div id='divid'></div>");
        });
		
        xit("div render with id style & class", function(){
            div.id = 'divid';
            div.style = 'style';
            div.cssClass = 'class';
            expect(div.render()).toEqual("<div id='divid' class='class' style='style'></div>");
        });
		
        xit("div disabled", function(){
            div.id = 'divid';
            div.disabled = true;
            expect(div.render()).toEqual("<div id='divid' disabled='disabled'></div>");
        });
		
        xit("div add css class", function(){
            div.id = 'divid';
            div.cssClass = 'classOne';
            div.addCssClass('classTwo');
            expect(div.render()).toEqual("<div id='divid' class='classOne classTwo'></div>");
        });
		
        xit("div render with visible style", function(){
            div.id = 'divid';
            div.style = 'style;';
            div.cssClass = 'class';
            div.visible = true;
            expect(div.render()).toEqual("<div id='divid' class='class' style='style;visibility:visible;'></div>");
        });
		
        xit("div render with a two controls", function(){
            var label = new Label();
            label.text = "Label";
            var textBox = new TextBox();
            textBox.disabled = true;
            div.addControl(label);
            div.addControl(textBox);
            expect(div.render()).toEqual("<div><label>Label</label><input type='text' disabled='disabled'></input></div>");
        });
    });
});
