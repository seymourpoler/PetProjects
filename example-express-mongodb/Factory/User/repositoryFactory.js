'use strict';

var configuration = require('../../configuration');
var theUserRepository = require('../../User/Repositories/userRepository');

function RepositoryFactory(){
  this.userRepository = function(){
    return new theUserRepository(configuration);
  };
}

module.exports = new RepositoryFactory();
