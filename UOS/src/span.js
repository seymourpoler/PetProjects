(function(UOS){
    UOS.Span = function Span(configuration){
        var self = this;
        //TODO: extract explanatory method
        var _cssClass = configuration && configuration.cssClass? configuration.cssClass : ''; 
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
		
        self.render = function(){
            if(!configuration){
                return '<span></span>';
            }
            let result = '<span';
            if(configuration.id){
                result = result + " id='" + configuration.id + "'";
            }
            if(configuration.name){
                result = result + " name='" + configuration.name + "'";
            }
            if(configuration.style){
                result = result + " style='" + configuration.style + "'";
            }
			if(isDisabled){
				result = result + ' disabled';
			}
            if(_cssClass){
                result = result + " class='" + _cssClass + "'";
            }
            
            result = result + '></span>';
            return result;
        };
    }
})(UOS || {});