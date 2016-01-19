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
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log('error on conection for saving: ', err); }

      var collection = db.collection(collectionName);
      console.log('getTitle: ', task.getTitle());
      var taskToBeSaved = {title: task.getTitle()};

      collection.insert(taskToBeSaved, function(err, result) {
        if(err) { return console.log('error on save: ', err); }

        console.log('insert: ', result);
        db.close();
      });
    });
  };

  this.detele = function(){
    mongoClient.connect(configuration.getConnectionString(), function(err, db) {
      if(err) { return console.log('error on conection for deleting: ', err); }

      var collection = db.collection(collectionName);
      collection.remove();
      db.close();
    });
  };
  
}

module.exports = TaskRepository;
