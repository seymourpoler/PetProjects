'use strict';
var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var path = require("path");
var configuration = require('./configuration');
//var taskApiRouter = require('./Task/Router/apiRouter');
var userRouterConfigurator = require('./User/Router/routerConfigurator');
var taskRouterConfigurator = require('./Task/Router/routerConfigurator');

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

var port = process.env.PORT || configuration.getServerPort();

//app.use('/api', taskApiRouter);
userRouterConfigurator.configure(app);
taskRouterConfigurator.configure(app);

app.use('/lib', express.static(__dirname + '/lib'));

app.use('/Home/Scripts', express.static(__dirname + '/Home/Scripts'));

app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname + '/Home/Views/index.html'));
});
/*
app.use('/Task/Scripts', express.static(__dirname + '/Task/Scripts'));
app.get('/tasks', function(req, res) {
    res.sendFile(path.join(__dirname + '/Task/Views/index.html'));
});
*/
app.get('/about',function(req,res){
  res.sendFile(path.join(__dirname + '/About//Views/index.html'));
});

app.listen(port);
console.log('Magic happens on port ' + port);
