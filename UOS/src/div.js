(function(UOS){
	
    function Div(configuration){
        let self = this;
		UOS.Controls.BaseControl.call(self, {...configuration, tag: 'div'});
        
        self.render = function(){
            const result = self.renderControl();
			return result;
        };
    }

    function createDiv(configuration){
        return new Div(configuration);
    }

    UOS.namespace('Controls');
    UOS.Controls.createDiv = createDiv;

})(UOS);