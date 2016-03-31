var express = require('express');
var path = require("path");
var taskApiRouter = require('./apiRouter');

function RouterConfigurator(){
  this.configure = function(app){
    app.use('/Task/Scripts', express.static(__dirname + '/../Scripts'));
    app.get('/tasks', function(req, res) {
        res.sendFile(path.join(__dirname + '/../Views/index.html'));
    });
    app.use('/api', taskApiRouter);
  };
}

module.exports = new RouterConfigurator();
