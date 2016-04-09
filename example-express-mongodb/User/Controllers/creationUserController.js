'use strict';

function CreationUserController(userRepository){

  this.create = function(request, response){
    var user = {};
    user.name = request.body.name;
    userRepository.save(user);
    response.json({ message: 'user created' });
  };
}

module.exports = CreationUserController;
