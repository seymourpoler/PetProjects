function config(routes){
    var self = this;
    var currentUrl;
    
    //app.stack[4].route.methods.path
    
    self.shouldMap = function(url){
        currentUrl = url;
        return self;
    };
    
    self.to = function(){
        return self;
    };
    
    return self;
}

module.exports = config;