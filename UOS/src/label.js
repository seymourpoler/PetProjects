(function(UOS){
    
    function Label(configuration){
        let self = this;
		UOS.Controls.BaseControl.apply(self, Array.prototype.slice.call(arguments));
        
        self.render = function(){
            const result = self.renderControl({...configuration, tag: 'label'});
			return result;
        };
    }

    function createLabel(configuration){
        return new Label(configuration);
    }

    UOS.namespace('Controls');
    UOS.Controls.createLabel = createLabel;

})(UOS);
