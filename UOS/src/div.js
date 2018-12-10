(function(UOS){
    UOS.Div = function Div(configuration){
        let self = this;
    
        self.render = function(){
            if(!configuration){
                return '<div></div>';
            }
            let result = '<div';
            if(configuration.id){
                result = result + " id='" + configuration.id + "'";
            }
            if(configuration.name){
                result = result + " name='" + configuration.name + "'";
            }
            if(configuration.style){
                result = result + " style='" + configuration.style + "'";
            }
    
            if(configuration.cssClass){
                result = result + " class='" + configuration.cssClass + "'";
            }
            
            result = result + '></div>';
            return result;
        };
    }
})(UOS);