describe('Div control', function(){
    it("Simple div render", function(){
        let div = UOS.Controls.createDiv();

        const result = div.render();

        expect(result).toEqual('<div></div>');
    });

    it("div render with id", function(){
        let div = UOS.Controls.createDiv({id: 'div-id'});

        const result = div.render();

        expect(result).toEqual("<div id='div-id'></div>");
    });

    it("div render with name", function(){
        let div = UOS.Controls.createDiv({name: 'div-name'});

        const result = div.render();

        expect(result).toEqual("<div name='div-name'></div>");
    });

    it("div render with id and style", function(){
        let div = UOS.Controls.createDiv({id: 'div-id', style: 'style'});

        const result = div.render();

        expect(result).toEqual("<div id='div-id' style='style'></div>");
    });

    it("div render with class", function(){
        const cssClass = 'css-class';
        let div = UOS.Controls.createDiv({cssClass: cssClass});
        
        const result  = div.render();
        
        expect(result).toEqual("<div class='"  + cssClass + "'></div>");
    });
});