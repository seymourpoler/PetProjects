'use strict';

var configuration = require('../../configuration');
var theUserRepository = require('../Repositories/userRepository');
var userRepository = new theUserRepository(configuration);

function CreateController(){

  this.create = function(request, response){
    var user = {};
    user.name = request.body.name;
    userRepository.save(user);
    response.json({ message: 'user created' });
  };
}

module.exports = new CreateController();
