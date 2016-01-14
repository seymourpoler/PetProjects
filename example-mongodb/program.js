var configuration = require('./configuration');
var TheRepo = require('./userRepository');
var userRepository = new TheRepo(configuration);

console.log(userRepository);
var userOne = {
  firstName:'John',
  lastName:'Keeve',
  age:12,
  profession: 'software developer'
};
var userTwo = {
  firstName:'Mark',
  lastName:'Thonsom',
  age:34,
  profession: 'agile coach'
};
userRepository.save(userOne);
userRepository.save(userTwo);

userRepository.find(findHandler);
function findHandler(items){
  console.log('all items: ', items);
}
userRepository.findOne(userOne, findOneHandler);
function findOneHandler(item){
  console.log('One item: ', item);
}

userRepository.deleteOne(userTwo, deleteOneHandler);
function deleteOneHandler(result){
  console.log('delete One: ', result);
}

userRepository.delete();
userRepository.find(findHandler);
function findHandler(items){
  console.log('all items again: ', items);
}
