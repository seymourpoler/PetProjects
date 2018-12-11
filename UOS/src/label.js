(function(UOS){
    UOS.Label = function Label(controlRenderer, configuration){
        var self = this;
        
        self.render = function(){
            if(!configuration){
                return '<label></label>';
            }
            const result = controlRenderer.render({...configuration, tag: 'label'});
            return result;
        };
    }

    function createLabel(configuration){
        return new UOS.Controls.Label(
            UOS.Controls.createControlRenderer(),
            configuration);
    }

    UOS.namespace('Controls');
    UOS.Controls.createLabel = createLabel;
    UOS.Controls.label = Label;

})(UOS);
