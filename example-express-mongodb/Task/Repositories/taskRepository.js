'use strict';
var mongoClient = require('mongodb').MongoClient;
var ObjectId = require('mongodb').ObjectID;

function taskRepository(){
  const collectionName = 'task';

  this.save = function(task){
    throw 'not implemented';
  };

  this.detele = function(taksId){
    throw 'not implemented';
  };
}
