(function(UOS){
    function Span(controlRenderer, configuration){
        var self = this;
        //TODO: extract explanatory method
        var _cssClass = configuration && configuration.cssClass? configuration.cssClass : ''; 
		let _style = configuration && configuration.style? configuration.style : '';
		let isDisabled = false;
    
        self.removeCssClass = function(cssClass){
            _cssClass = _cssClass.replace(cssClass, '');
        };
        
		self.disable = function(){
			isDisabled = true;
		};
		
		self.enable = function(){
			isDisabled = false;
		};
		
		self.hide = function(){
			_style = _style + 'display:none;';
		};
		
		self.show = function(){
			_style = _style + 'display:block;';
		};
		
        self.render = function(){
            if(!configuration){
                return '<span></span>';
            }
			const result = controlRenderer.render({...configuration, tag:'span', style: _style, css: _cssClass, disabled: isDisabled});
			return result;
        };
    }
	
	function createSpan(configuration){
		return new Span(
			UOS.Controls.createControlRenderer(),
			configuration);
	}
	
	UOS.namespace('Controls');
	UOS.Controls.createSpan = createSpan;
	
})(UOS);