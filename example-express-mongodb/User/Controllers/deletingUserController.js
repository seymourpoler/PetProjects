'use strict';

function DeletingUserController(userRepository){

  this.delete = function(request, response){
    var userId = req.params.id;
    userRepository.deleteOne(userId, function(data){
      res.json({ user: data });
    });
  };
}
