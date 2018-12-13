(function(UOS){
	
	function DropDown(configuration){
		let self = this;
		UOS.Controls.BaseControl.call(self, {...configuration, tag: 'select'});
		
		self.render = function(){
			const result = self.renderControl();
			return result;
		};
	}
	
	function createDropDown(configuration){
		return new DropDown(configuration);
	}
	
	UOS.namespace('Controls');
	UOS.Controls.createDropDown = createDropDown;
	
})(UOS);