(function(UOS){
	
	function Button(configuration){
		let self = this;	
		UOS.Controls.BaseControl.call(self, {...configuration, tag: 'button'});

		self.render = function(){
			const result = self.renderControl();
			return result;
		};
	}
	
	function createButton(configuration){
		return new Button(configuration);
	}
	
	UOS.namespace('Controls');
	UOS.Controls.createButton = createButton;
	
})(UOS);