'use strict';
var mongoClient = require('mongodb').MongoClient;
var ObjectId = require('mongodb').ObjectID;

function UserRepository(configuration){
  const collectionName = 'user';

  this.save = function(user){
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log('error on conection for saving: ', err); }

      var collection = db.collection(collectionName);
      collection.insert(user, function(err, result) {
        if(err) { return console.log('error on save: ',err); }
        console.log('insert: ', result);
        db.close();
      });
    });
  };
  this.delete = function(){
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log('error on conection for deleting: ', err); }

      var collection = db.collection(collectionName);
      collection.remove();
      db.close();
    });
  };

  this.deleteOne = function(userId, deleteOneHandler){
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log('error on conection for deleting one: ', err); }

      var collection = db.collection(collectionName);
      collection.deleteOne({"_id": new ObjectId(userId)}, function(err, result){
        if(err) { return console.log('error on delete one: ', err); }
        deleteOneHandler(result);
        db.close();
      });
    });
  };

  this.findOne = function(userId, findOneHandler){
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log('error on conection for finding one: ', err); }

      var collection = db.collection(collectionName);
      collection.findOne({"_id": new ObjectId(userId)}, function(err, item) {
        if(err) { return console.log('error on find one: ',err); }
        findOneHandler(item);
        db.close();
      });
    });
  };

  this.find = function(findHandler){
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log('error on conection for finding: ', err); }

      var collection = db.collection(collectionName);
      collection.find().toArray(function(err, data){
        if(err) { return console.log('error on find: ',err); }
        findHandler(data);
        db.close();
      });
    });
  };
}

module.exports = UserRepository;
