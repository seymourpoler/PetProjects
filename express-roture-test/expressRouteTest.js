function config(app){
    var self = this;
    var currentUrl;
       
    self.shouldMap = function(url){
        currentUrl = url;
        return self;
    };
    
    self.to = function(method){
      for(var position = 0; position < app._router.stack.length; position++){
          if(app._router.stack[position].route && 
                app._router.stack[position].route.path == currentUrl &&
                hasMethod(method)){
              return true;
          }
      }
      
      
      function hasMethod(method){
          for(var position=0; position < app._router.stack[position].route.stack.length; position++){
              if(app._router.stack[position].route.stack.method == method){
                  return true;
              }
          }
          return false;
      }
      return false;          
    };
    
    return self;
}

module.exports = config;