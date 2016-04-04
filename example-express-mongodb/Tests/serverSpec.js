'use strict';
var request = require('request');

it("should respond with hello world", function(done) {
  request("http://localhost:8080/", function(error, response, body){
    done();
  });
}, 250);
