(function(UOS){
    function Div(controlRenderer, configuration){
        let self = this;
    
        self.render = function(){
            if(!configuration){
                return '<div></div>';
            }
            const result = controlRenderer.render({...configuration, tag: 'div'});
            return result;
        };
    }

    function createDiv(configuration){
        return new Div(
            UOS.Controls.createControlRenderer(),
            configuration);
    }

    UOS.namespace('Controls');
    UOS.Controls.createDiv = createDiv;

})(UOS);