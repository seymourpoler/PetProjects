'use strict';
var express = require('express');
var router = express.Router();
var configuration = require('../../configuration');
var theUserRepository = require('../Repositories/userRepository');
var userRepository = new theUserRepository(configuration);

var router = express.Router();
router.get('/', function(req, res) {
    res.json({ message: 'Wellcome to our api!' });
});
router.get('/users', function(req, res) {
  userRepository.find(function(data){
    res.json({ user: data });
  });
});
router.get('/users/:id', function(req, res) {
  var userId = req.params.id;
  userRepository.findOne(userId, function(data){
    res.json({ user: data });
  });
});
router.post('/users', function(req, res) {
  var user = {};
  user.name = req.body.name;
  userRepository.save(user);
  res.json({ message: 'user created' });
});
router.delete('/users/:id', function(req, res) {
  var userId = req.params.id;
  userRepository.deleteOne(userId, function(data){
    res.json({ user: data });
  });
});

module.exports = router;
