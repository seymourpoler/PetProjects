(function(UOS){
	
	function BaseControl(configuration){
		let self = this;
		let isDisabled = false;
        let _cssClass = configuration && configuration.cssClass? configuration.cssClass : ''; 
		let _style =  configuration && configuration.style? configuration.style: '';
		
		const configurationErrorMessage = 'There is no configuration';
		self.configurationErrorMessage = configurationErrorMessage;
		
		const tagConfigurationErrorMessage = 'There is no tag property in configuration parameter';
		self.tagConfigurationErrorMessage = tagConfigurationErrorMessage;
		
		self.disable = function(){
			isDisabled = true;
		};
		
		self.enable = function(){
			isDisabled = false;
		};
		
		self.removeCssClass = function(cssClass){
            _cssClass = _cssClass.replace(cssClass, '');
		};

		self.addCssClass = function(cssClass){
            _cssClass = _cssClass + ' ' + cssClass;
		};

		self.addStyle = function(style){
            _style = _style + style;
		};
		
		self.hide = function(){
			_style = _style + 'display:none;';
		};
		
		self.show = function(){
			_style = _style + 'display:block;';
		};

		self.renderControl = function(){
			if(!configuration){
				throw new Error(configurationErrorMessage);
			}
			
			if(!configuration.tag){
				throw new Error(tagConfigurationErrorMessage);
			}

			let result = '<' + configuration.tag;
			
			if(configuration.id){
				result = result + " id='" + configuration.id + "'";
			}
			
			if(configuration.name){
				result = result + " name='" + configuration.name + "'";
			}
			
			if(!!_cssClass){
				result = result + " class='" + _cssClass + "'";
			}
			
			if(!!_style){
				result = result + " style='" + _style + "'";
			}
			
			if(configuration.type){
				result = result + " type='" + configuration.type + "'";
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