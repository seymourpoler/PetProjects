describe('Link Control', function(){
    it("Simple link render", function(){
        let link = new Link();

        const result = link.render();

        expect(result).toEqual('<a></a>');
    });
});