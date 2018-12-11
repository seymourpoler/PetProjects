(function(UOS){
	function ControlRenderer(){
		var self = this;

		const configurationErrorMessage = 'There is no configuration';
		const tagConfigurationErrorMessage = 'There is no tag property in configuration parameter';

		self.configurationErrorMessage = configurationErrorMessage;
		self.tagConfigurationErrorMessage = tagConfigurationErrorMessage;

		self.render = function(configuration){
			if(!configuration){
				throw new Error(configurationErrorMessage);
			}
			if(!configuration.tag){
				throw new Error(tagConfigurationErrorMessage);
			}
			return '<' + configuration.tag + '></' + configuration.tag + '>';
		}
	};

	UOS.ControlRenderer = ControlRenderer;

})(UOS)