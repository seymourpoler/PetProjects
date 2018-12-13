(function(UOS){
    function Link(configuration){
        let self = this;
		UOS.Controls.BaseControl.call(self, {...configuration, tag: 'a'});
    
        self.render = function(){
            const result = self.renderControl();
			return result;
        };
    }
    function createLink(configuration){
        return new Link(configuration);
    }

    UOS.namespace('Controls');
    UOS.Controls.createLink = createLink;

})(UOS);