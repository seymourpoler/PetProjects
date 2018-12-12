(function(UOS){
	
    function Div(configuration){
        let self = this;
		UOS.Controls.BaseControl.apply(self, Array.prototype.slice.call(arguments));
		
        self.render = function(){
            const result = self.renderControl({...configuration, tag: 'div'});
			return result;
        };
    }

    function createDiv(configuration){
        return new Div(configuration);
    }

    UOS.namespace('Controls');
    UOS.Controls.createDiv = createDiv;

})(UOS);