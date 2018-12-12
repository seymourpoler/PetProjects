(function(UOS){
    function Link(controlRenderer, configuration){
        let self = this;
    
        self.render = function(){
            if(!configuration){
                return '<a></a>';
            }
            const result = controlRenderer.render({...configuration, tag: 'a'});
            return result;
        };
    }
    function createLink(configuration){
        return new Link(
            UOS.Controls.createControlRenderer(),
            configuration);
    }

    UOS.namespace('Controls');
    UOS.Controls.createLink = createLink;

})(UOS);