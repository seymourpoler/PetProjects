(function(UOS){
    function Link(configuration){
        let self = this;
		UOS.Controls.BaseControl.apply(self, Array.prototype.slice.call(arguments));
    
        self.render = function(){
            const result = self.renderControl({...configuration, tag: 'a'});
			return result;
        };
    }
    function createLink(configuration){
        return new Link(configuration);
    }

    UOS.namespace('Controls');
    UOS.Controls.createLink = createLink;

})(UOS);