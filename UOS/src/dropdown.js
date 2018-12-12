(function(UOS){
	function Dropdown(controlRenderer, configuration){
		let self = this;
		
		self.render = function(){
			if(!configuration){
                return '<select></select>';
            }
			
			throw 'not implemented';
		};
	}
	
	function createDropDown(configuration){
		return new Dropdown(
			UOS.Controls.createControlRenderer(),
			configuration);
	}
	
	UOS.namespace('Controls');
	UOS.Controls.createDropDown = createDropDown;
	
})(UOS);