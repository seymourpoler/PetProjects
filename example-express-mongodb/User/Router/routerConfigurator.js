'use strict';
var express = require('express');
var path = require("path");
var userApiRouter = require('./apiRouter');

function RouterConfigurator(){
  this.configure = function(app){
    app.use('/User/Scripts', express.static(__dirname + '/../Scripts'));
    app.get('/users', function(req, res) {
        res.sendFile(path.join(__dirname + '/../Views/index.html'));
    });
    app.use('/api', userApiRouter);
  };
}

module.exports = new RouterConfigurator();
