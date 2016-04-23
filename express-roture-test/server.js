var express = require('express');
var config = require('./expressRouteTest');

var app = express();

app.get('/users', function(req, res){
    res.send('Users');
});

app.get('/users/:id', function(req, res){
    res.send('Users --> id');
});

app.put('/users', function(req, res){
    res.send('Users --> id');
});


config(app)
        .shouldMap('/users')
        .to('get');
        
config(app)
        .shouldMap('/users/:id')
        .to('get');
        
config(app)
        .shouldMap('/users')
        .to('put');