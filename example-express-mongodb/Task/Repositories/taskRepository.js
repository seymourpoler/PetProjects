'use strict';
var mongoClient = require('mongodb').MongoClient;
var ObjectId = require('mongodb').ObjectID;

function TaskRepository(configuration){
  const collectionName = 'task';

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

  this.save = function(task){
    throw 'not implemented';
  };

  this.detele = function(taksId){
    throw 'not implemented';
  };
}

module.exports = TaskRepository;
