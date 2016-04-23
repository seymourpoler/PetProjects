var express = require('express');

var app = express();

app.put('/users', function(req, res){
    res.send('Users');
});

app.get('/users/:id', function(req, res){
    res.send('Users --> id');
});

app.delete('/users', function(req, res){
    res.send('Users --> id');
});


module.exports = app;