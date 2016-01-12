function Configuration(){
  this.getConnectionString = function(){
    return 'mongodb://localhost:27017/exampleDb';
  };
}

module.exports = new Configuration();
