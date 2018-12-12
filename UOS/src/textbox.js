(function(UOS){
    function TextBox(controlRenderer, configuration){
        var self = this;
		
        this.tag = 'input';
        this.type = 'text';
        this.text = '';
        
        self.render = function(){
			if(!configuration){
				return "<input type='text'/>";
			}
            const result = controlRenderer.render({...configuration, tag: 'input', type:'text'});
			return result;
        };
    }
	
	function createTextBox(configuration){
		return new UOS.Controls.TextBox(
			UOS.Controls.createControlRenderer(),
			configuration);
	}
	
	UOS.namespace("Controls");
	UOS.Controls.TextBox = TextBox;
	UOS.Controls.createTextBox = createTextBox;
	
})(UOS);