'use strict';
var request = require('supertest')
  , app = require('./server');

describe('GET /user', function(){
  var sever;
  beforeEach(function(){
    
  });
  it('should respond with json', function(done){
    request(app)
      .get('/user')
      .set('Accept', 'application/json')
      .expect('Content-Type', 'json')
      .expect(200, done);
  })
})
