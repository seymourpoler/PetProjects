var configuration = require('../../configuration');
var theUserRepository = require('../Repositories/userRepository');
var userRepository = new theUserRepository(configuration);

function FindController(){

  this.findBy = function(request, response){
    var userId = request.params.id;
    userRepository.findOne(userId, function(data){
      response.json({ user: data });
    });
  };

  this.find = function(request, response){
    userRepository.find(function(data){
      response.json({ user: data });
    });
  };
}
module.exports = new FindController();
