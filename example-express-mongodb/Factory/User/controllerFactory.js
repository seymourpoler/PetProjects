'use strict';

var repositoryFactory = require('./repositoryFactory');
var SearchUserController = require('../../User/Controllers/searchUserController');
var CreatingUserController = require('../../User/Controllers/creationUserController');
var DeletingUserController = require('../../User/Controllers/deletingUserController');

function ControllerFactory(){
  
  this.searchUserController = function(){
    return new SearchUserController(
          repositoryFactory.userRepository());
  };

  this.creationUserController = function(){
    return new CreationUserController(
          repositoryFactory.userRepository());
  };

  this.deletingUserController = function(){
    return new DeletingUserController(
          repositoryFactory.userRepository());
  };
}

module.exports = new ControllerFactory();
