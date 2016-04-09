'use strict';

function CreatingUserController(userRepository){

  this.create = function(request, response){
    var user = {};
    user.name = request.body.name;
    userRepository.save(user);
    response.json({ message: 'user created' });
  };
}

module.exports = CreatingUserController;
