/*
 * express route test
 * Released under the MIT license
 * email: seymourpoler@gmail.com
 */

function config(app){
    var self = this;
    var currentVerb;
       
    self.withVerb = function(verb){
        currentVerb = verb;
        return self;
    };
    
    self.forUrl = function(url){
      for(var position = 0; position < app._router.stack.length; position++){
          if(app._router.stack[position].route && 
                app._router.stack[position].route.path == url &&
                hasVerbFor(currentVerb, app._router.stack[position].route)){
              return console.log('has verb: ' + currentVerb + ' for url: ' + url);
          }
      }
      throw new Error('there is NO verb: ' + currentVerb + ' for: ' + url);
      
      function hasVerbFor(verb, route){
          for(var position=0; position < route.stack.length; position++){
              if(route.stack[position].method == verb){
                  return true;
              }
          }
          return false;
      }        
    };
    
    return self;
}

module.exports = config;