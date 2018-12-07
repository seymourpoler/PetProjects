UOS.Span = function Span(configuration){
    var self = this;

    self.removeCssClass = function(cssClass){
        throw 'not implemented';
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

        if(configuration.cssClass){
            result = result + " class='" + configuration.cssClass + "'";
        }
        
        result = result + '></span>';
        return result;
    };
}