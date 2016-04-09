'use strict';

function Configuration(){
  this.getConnectionString = function(){
    return 'mongodb://localhost:27017/exampleDb';
  };
  this.getServerPort = function(){
    return 8080;
  };
}

module.exports = new Configuration();
