'use strict';

var repositoryFactory = require('./repositoryFactory');
var SearchUserController = require('../../User/Controllers/searchUserController');
var CreatingUserController = require('../../User/Controllers/creatingUserController');

function ControllerFactory(){
  this.searchUserController = function(){
    return new SearchUserController(
          repositoryFactory.userRepository());
  };

  this.creatingUserController = function(){
    return new CreatingUserController(
          repositoryFactory.userRepository());
  };
}

module.exports = new ControllerFactory();
