'use strict';

var controllerFactory = require('./controllerFactory');

function RouterConfigurator(express, path){

  this.configure = function(app){
    app.use('/User/Scripts', express.static(__dirname + '/../../User/Scripts'));
    app.get('/users', function(req, res) {
        res.sendFile(path.join(__dirname + '/../../User/Views/index.html'));
    });
    app.get('/api/users', function(req, res) {
      controllerFactory.searchUserController().search(req, res);
    });
    app.get('/api/users/:id', function(req, res) {
      controllerFactory.searchUserController().searchBy(req, res);
    });
    app.post('/api/users', function(req, res) {
      controllerFactory.creationUserController().create(req, res);
    });

    app.delete('/api/users/:id', function(req, res) {
      controllerFactory.deletingUserController().delete(req, res);
    });

  };
}

module.exports = RouterConfigurator;
