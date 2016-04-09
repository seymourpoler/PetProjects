'use strict';

var controllerFactory = require('./controllerFactory');

function RouterConfigurator(express, path){

  this.configure = function(app){
    app.use('/User/Scripts', express.static(__dirname + '/../../User/Scripts'));
    app.get('/users', function(req, res) {
        res.sendFile(path.join(__dirname + '/../../User/Views/index.html'));
    });
    app.get('/api/users', function(req, res) {
      controllerFactory.findController().find(req, res);
    });
    app.get('/api/users/:id', function(req, res) {
      controllerFactory.findController().findBy(req, res);
    });
    app.post('/api/users', function(req, res) {
      controllerFactory.createController().create(req, res);
    });

    app.delete('/api/users/:id', function(req, res) {
      var userId = req.params.id;
      userRepository.deleteOne(userId, function(data){
        res.json({ user: data });
      });
    });
  };
}

module.exports = RouterConfigurator;
