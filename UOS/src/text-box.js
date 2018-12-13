(function(UOS){
	
    function TextBox(configuration){
        var self = this;
		UOS.Controls.BaseControl.call(self, {...configuration, tag: 'input', type:'text'});
		       
        self.render = function(){
			const result = self.renderControl();
			return result;
        };
    }
	
	function createTextBox(configuration){
		return new TextBox(configuration);
	}
	
	UOS.namespace("Controls");
	UOS.Controls.createTextBox = createTextBox;
	
})(UOS);