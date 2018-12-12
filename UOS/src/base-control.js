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
			
			if(configuration.name){
				result = result + " name='" + configuration.name + "'";
			}
			
			if(configuration.cssClass){
				result = result + " class='" + configuration.cssClass + "'";
			}
			
			if(configuration.style){
				result = result + " style='" + configuration.style + "'";
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