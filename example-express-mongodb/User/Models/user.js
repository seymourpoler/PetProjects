function User(state){
  var id = state.id;
  var name = state.name;
  var age = state.age;

  this.getId = function(){
    return id;
  };

  this.getName = function(){
    return name;
  };

  this.getAge = function(){
    return age;
  };
}

module.exports = User;
