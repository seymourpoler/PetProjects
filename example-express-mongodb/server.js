'use strict';
var express = require('express');
var app = express();
var bodyParser = require('body-parser');
var path = require("path");
var configuration = require('./configuration');

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

var port = process.env.PORT || configuration.getServerPort();

var taskApiRouter = require('./Task/Router/apiRouter');
var userApiRouter = require('./User/Router/apiRouter');

app.use('/api', userApiRouter);
app.use('/api', taskApiRouter);

app.use('/Home/Scripts', express.static(__dirname + '/Home/Scripts'));
app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname + '/Home/Views/index.html'));
});
app.get('/about',function(req,res){
  res.sendFile(path.join(__dirname + '/About//Views/index.html'));
});

app.listen(port);
console.log('Magic happens on port ' + port);
