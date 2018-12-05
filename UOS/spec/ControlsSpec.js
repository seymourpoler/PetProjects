describe("Controls", function () {
    xdescribe("DIV Control", function () {
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
});
