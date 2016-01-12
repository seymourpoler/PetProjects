var configuration = require('./configuration');
var TheRepo = require('./userRepository');
var userRepository = new TheRepo(configuration);

console.log(userRepository);

userRepository.find(findHandler);
function findHandler(data){
  console.log('data: ', data);
}
