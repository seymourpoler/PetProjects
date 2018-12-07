(function(UOS){
    UOS.Link = function Link(configuration){
        let self = this;
    
        self.render = function(){
            if(!configuration){
                return '<a></a>';
            }
            let result = '<a';
            if(configuration.id){
                result = result + " id='" + configuration.id + "'";
            }
            result = result + '></a>';
            return result;
        };
    }
})(UOS || {});