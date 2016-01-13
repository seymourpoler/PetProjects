var configuration = require('./configuration');
var TheRepo = require('./userRepository');
var userRepository = new TheRepo(configuration);

console.log(userRepository);
var user = {
  firstName:'John',
  lastName:'Keeve',
  age:12,
  profession: 'software developer'
};
userRepository.save(user);

userRepository.find(findHandler);
function findHandler(items){
  console.log('all items: ', items);
}
userRepository.findOne(user, findOneHandler);
function findOneHandler(item){
  console.log('One item: ', item);
}

userRepository.delete();
userRepository.find(findHandler);
function findHandler(items){
  console.log('all items again: ', items);
}
