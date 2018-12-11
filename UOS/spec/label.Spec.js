describe('Label', function(){
    it("Simple label render", function(){
        var label = UOS.Controls.createLabel();

        const result = label.render();

        expect(result).toEqual('<label></label>');
    });

    it("renders with an identifier", function(){
        var label = UOS.Controls.createLabel({id:'label-id'});

        const result = label.render();

        expect(result).toEqual("<label id='label-id'></label>");
    });
});