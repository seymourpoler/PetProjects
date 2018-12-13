(function(UOS){
    
    function Label(configuration){
        var self = this;
		UOS.Controls.BaseControl.call(self, {...configuration, tag: 'label'});
        
        self.render = function(){
            const result = self.renderControl();
			return result;
        };
    }

    function createLabel(configuration){
        return new Label(configuration);
    }

    UOS.namespace('Controls');
    UOS.Controls.createLabel = createLabel;

})(UOS);
