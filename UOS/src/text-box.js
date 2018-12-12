(function(UOS){
    function TextBox(configuration){
        var self = this;
		UOS.Controls.BaseControl.apply(self, Array.prototype.slice.call(arguments));
		       
        self.render = function(){
			const result = self.renderControl({...configuration, tag: 'input', type:'text'});
			return result;
        };
    }
	
	function createTextBox(configuration){
		return new TextBox(configuration);
	}
	
	UOS.namespace("Controls");
	UOS.Controls.createTextBox = createTextBox;
	
})(UOS);