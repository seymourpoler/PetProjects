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
			let result = '<' + configuration.tag;
			
			if(configuration.id){
				result = result + " id='" + configuration.id + "'";
			}
			
			if(isDisabled){
				result = result + " disabled";
			}

			result = result + '></' + configuration.tag + '>';
			return result;
		};
	}
	
	UOS.namespace('Controls');
	UOS.Controls.BaseControl = BaseControl;
	
})(UOS);