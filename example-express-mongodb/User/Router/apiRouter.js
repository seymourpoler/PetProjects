'use strict';
var express = require('express');
var router = express.Router();
var findController = require('../Controllers/findController');
var createController = require('../Controllers/createController');

router.get('/', function(req, res) {
    res.json({ message: 'Wellcome to our api!' });
});

router.get('/users', function(req, res) {
  findController.find(req, res);
});

router.get('/users/:id', function(req, res) {
  findController.findBy(req, res);
});

router.post('/users', function(req, res) {
  createController.create(req, res);
});

router.delete('/users/:id', function(req, res) {
  var userId = req.params.id;
  userRepository.deleteOne(userId, function(data){
    res.json({ user: data });
  });
});

module.exports = router;
