'use strict';
var mongoClient = require('mongodb').MongoClient;

function UserRepository(configuration){
  const collectionName = 'user';

  this.save = function(user){
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log(err); }

      var collection = db.collection(collectionName);
      collection.insert(user, function(err, result) {
        if(err) { return console.log('insert:',err); }
        console.log('insert: ', result);
      });
      db.close();
    });
  };
  this.delete = function(){
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log(err); }

      var collection = db.collection(collectionName);
      collection.remove();
      db.close();
    });
  };

  this.deleteOne = function(user){
    throw 'not implemented';
  };

  this.findOne = function(user, findOneHandler){

    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log(err); }

      var collection = db.collection(collectionName);
      collection.findOne(user, function(err, item) {
        if(err) { return console.log('findOne',err); }
        findOneHandler(item);
        db.close();
      });
    });
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
