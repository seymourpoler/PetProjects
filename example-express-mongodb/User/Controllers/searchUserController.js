'use strict';

function SearchUserController(userRepository){

  this.searchBy = function(request, response){
    var userId = request.params.id;
    userRepository.findOne(userId, function(data){
      response.json({ user: data });
    });
  };

  this.search = function(request, response){
    userRepository.find(function(data){
      response.json({ user: data });
    });
  };
}

module.exports = SearchUserController;
