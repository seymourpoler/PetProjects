(function(UOS){
	function DropDown(controlRenderer, configuration){
		let self = this;
		
		self.render = function(){
			if(!configuration){
                return '<select></select>';
            }
			
			throw 'not implemented';
		};
	}
	
	function createDropDown(configuration){
		return new DropDown(
			UOS.Controls.createControlRenderer(),
			configuration);
	}
	
	UOS.namespace('Controls');
	UOS.Controls.createDropDown = createDropDown;
	
})(UOS);