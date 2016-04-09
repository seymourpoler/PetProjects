'use strict';

var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var path = require('path');
var configuration = require('./configuration');
var theUserRouterConfigurator = require('./Factory/User/routerConfigurator');
var userConfigurator = new theUserRouterConfigurator(express, path);
var taskRouterConfigurator = require('./Task/Router/routerConfigurator');



app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

userConfigurator.configure(app);
taskRouterConfigurator.configure(app);

app.use('/lib', express.static(__dirname + '/lib'));

app.use('/Home/Scripts', express.static(__dirname + '/Home/Scripts'));

app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname + '/Home/Views/index.html'));
});

app.get('/about',function(req,res){
  res.sendFile(path.join(__dirname + '/About/Views/index.html'));
});

var port = process.env.PORT || configuration.getServerPort();
var server = app.listen(port, function(){
    console.log('Magic happens on port ' + port);
});

module.exports = server;
