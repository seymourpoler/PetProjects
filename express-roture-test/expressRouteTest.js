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
                hasMethodFor(method, app._router.stack[position].route)){
              return console.log('has method: ' + method + ' for: ' + currentUrl);
          }
      }
      throw new Error('there is NO method: ' + method + ' for: ' + currentUrl);
      
      function hasMethodFor(method, route){
          for(var position=0; position < route.stack.length; position++){
              if(route.stack[position].method == method){
                  return true;
              }
          }
          return false;
      }        
    };
    
    return self;
}

module.exports = config;