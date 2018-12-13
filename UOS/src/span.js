(function(UOS){
    function Span(configuration){
        let self = this;
		UOS.Controls.BaseControl.call(self, {...configuration, tag: 'span'});

        self.render = function(){
            const result = self.renderControl();
			return result;
        };
    }
	
	function createSpan(configuration){
		return new Span(configuration);
	}
	
	UOS.namespace('Controls');
	UOS.Controls.createSpan = createSpan;
	
})(UOS);