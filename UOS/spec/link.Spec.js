describe('Link Control', function(){
    it("Simple link render", function(){
        let link = new UOS.Link();

        const result = link.render();

        expect(result).toEqual('<a></a>');
    });

    it("link render with id", function(){
        let link = new UOS.Link({id: 'link-id'});

        const result = link.render();

        expect(result).toEqual("<a id='link-id'></a>");
    });
});