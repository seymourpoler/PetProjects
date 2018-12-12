describe('TextBox Control', function(){
    it("Simple textbox render", function(){
        let textbox = new UOS.Controls.createTextBox();

        const result = textbox.render();

        expect(result).toEqual("<input type='text'/>");
    });
});