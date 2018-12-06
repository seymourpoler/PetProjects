describe('Label', function(){
    it("Simple label render", function(){
        var label = new UOS.Label();

        const result = label.render();

        expect(result).toEqual('<label></label>');
    });
});