(function(UOS){
	function BaseControl(){
		let self = this;
		let isDisabled = false;
		
		self.disable = function(){
			isDisabled = true;
		};
		
		self.enable = function(){
			isDisabled = false;
		};
		
		self.renderControl = function(configuration){
			return '<' + configuration.tag + '></' + configuration.tag + '>';
		};
	}
	
	UOS.namespace('Controls');
	UOS.Controls.BaseControl = BaseControl;
	
})(UOS);