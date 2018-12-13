(function(UOS){
	function DropDown(configuration){
		let self = this;
		UOS.Controls.BaseControl.apply(self, Array.prototype.slice.call(arguments));
		
		self.render = function(){
			const result = self.renderControl({...configuration, tag: 'select'});
			return result;
		};
	}
	
	function createDropDown(configuration){
		return new DropDown(configuration);
	}
	
	UOS.namespace('Controls');
	UOS.Controls.createDropDown = createDropDown;
	
})(UOS);