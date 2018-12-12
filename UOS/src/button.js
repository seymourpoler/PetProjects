(function(UOS){
	function Button(configuration){
		let self = this;	

		self.render = function(){
			const result = self.renderControl({...configuration, tag: 'button'});
			return result;
		};
	}
	Button.prototype = new UOS.Controls.BaseControl();
	
	function createButton(configuration){
		return new Button(configuration);
	}
	
	UOS.namespace('Controls');
	UOS.Controls.createButton = createButton;
	
})(UOS);