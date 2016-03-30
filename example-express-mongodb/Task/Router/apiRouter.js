'use strict';
var express = require('express');
var router = express.Router();
var configuration = require('../../configuration');
var theTaskRepository = require('../Repositories/taskRepository');
var taskRepository = new theTaskRepository(configuration);

router.get('/tasks', function(req, res){
  taskRepository.find(function(data){
    res.json({ task: data });
  });
});
router.post('/tasks', function(req, res){
  var task = new Task({title : req.body.title});
    taskRepository.save(task);
  res.json({ message: 'task created' });
});
router.delete('/tasks', function(req, res) {
  taskRepository.detele();
  res.json({ message: 'tasks removed' });
});

module.exports = router;
