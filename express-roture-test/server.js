var express = require('express');
var config = require('./expressRouteTest');

var app = express();

app.get('/users', function(req, res){
    res.send('Users');
});

app.get('/users/:id', function(req, res){
    res.send('Users --> id');
});

console.log(app.routes());

console.log(config);

config(app.routes)
    .shouldMap('/users');