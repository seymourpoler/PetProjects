(function(UOS){
	function ControlRenderer(){
		var self = this;

		const configurationErrorMessage = 'There is no configuration';
		const tagConfigurationErrorMessage = 'There is no tag property in configuration parameter';

		self.configurationErrorMessage = configurationErrorMessage;
		self.tagConfigurationErrorMessage = tagConfigurationErrorMessage;

		let result = '';

		self.render = function(configuration){
			if(!configuration){
				throw new Error(configurationErrorMessage);
			}
			if(!configuration.tag){
				throw new Error(tagConfigurationErrorMessage);
			}
			result = '<' + configuration.tag;
			if(configuration.id){
				result = result + " id='" + configuration.id + "'";
			}
			if(configuration.cssClass){
				result = result + " class='" + configuration.cssClass + "'";
			}
			if(configuration.style){
				result = result + " style='" + configuration.style + "'";
			}
			if(configuration.disabled){
				result = result + " disabled";
			}
			result = result + '></' + configuration.tag + '>';
			return result;
		}
	};

	UOS.ControlRenderer = ControlRenderer;

})(UOS)