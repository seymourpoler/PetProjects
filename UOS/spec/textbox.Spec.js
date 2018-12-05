describe('TextBox Control', function(){
    var textbox = null;

    beforeEach(function() {
        textbox = new TextBox();
    });

    it("Simple textbox render", function(){
        expect(textbox.render()).toEqual("<input type='text'/>");
    });
});