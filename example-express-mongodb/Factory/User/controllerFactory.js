'use strict';

var repositoryFactory = require('./repositoryFactory');
var FindController = require('../../User/Controllers/findController');
var CreateController = require('../../User/Controllers/createController');

function ControllerFactory(){
  this.findController = function(){
    return new FindController(
          repositoryFactory.userRepository());
  };

  this.createController = function(){
    return new CreateController(
          repositoryFactory.userRepository());
  };
}

module.exports = new ControllerFactory();
