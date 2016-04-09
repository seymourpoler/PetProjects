'use strict';

function DeletingUserController(userRepository){

  this.delete = function(request, response){
    var userId = request.params.id;
    userRepository.deleteOne(userId, function(data){
      response.json({ user: data });
    });
  };
}

module.exports = DeletingUserController;
