'use strict';
var mongoClient = require('mongodb').MongoClient;

function UserRepository(configuration){
  const collectionName = 'user';

  this.save = function(user){
    throw 'not implemented';
  };
  this.delete = function(user){
    throw 'not implemented';
  };
  this.findOne = function(user, findOneHandler){

  };
  
  this.find = function(findHandler){
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log(err); }

      var collection = db.collection(collectionName);
      collection.find().toArray(function(err, data){
        if(err) { return console.log(err); }
        findHandler(data);
        db.close();
      });
    });

  };
}

module.exports = UserRepository;
