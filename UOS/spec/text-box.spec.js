describe('TextBox Control', function(){
	
    it("Simple textbox render", function(){
        let textbox = new UOS.Controls.createTextBox();

        const result = textbox.render();

        expect(result).toEqual("<input type='text'></input>");
    });
	
	it("renders textbox with id", function(){
        let textbox = new UOS.Controls.createTextBox({id: 'textbox-id'});

        const result = textbox.render();

        expect(result).toEqual("<input id='textbox-id' type='text'></input>");
    });
	
});