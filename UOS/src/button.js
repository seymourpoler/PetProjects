(function(UOS){
	function Button(configuration){
		let self = this;	
		UOS.Controls.BaseControl.apply(self, Array.prototype.slice.call(arguments));

		self.render = function(){
			const result = self.renderControl({...configuration, tag: 'button'});
			return result;
		};
	}
	
	function createButton(configuration){
		return new Button(configuration);
	}
	
	UOS.namespace('Controls');
	UOS.Controls.createButton = createButton;
	
})(UOS);