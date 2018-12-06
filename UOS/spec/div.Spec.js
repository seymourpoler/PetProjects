describe('Div control', function(){
    it("Simple div render", function(){
        let div = new Div();

        const result = div.render();

        expect(result).toEqual('<div></div>');
    });

    it("div render with id", function(){
        let div = new Div({id: 'div-id'});

        const result = div.render();

        expect(result).toEqual("<div id='div-id'></div>");
    });

    it("div render with name", function(){
        let div = new Div({name: 'div-name'});

        const result = div.render();

        expect(result).toEqual("<div name='div-name'></div>");
    });

    it("div render with id and style", function(){
        let div = new Div({id: 'div-id', style: 'style'});

        const result = div.render();

        expect(result).toEqual("<div id='div-id' style='style'></div>");
    });

    it("div render with class", function(){
        const cssClass = 'css-class';
        let div = new Div({cssClass: cssClass});
        
        const result  = div.render();
        
        expect(result).toEqual("<div class='"  + cssClass + "'></div>");
    });
});