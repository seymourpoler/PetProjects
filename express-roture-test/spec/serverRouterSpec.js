var config = require('../lib/expressRouteTest');
var server = require('../src/server');

describe("Server Router Tests", function(){
        it("maps to put /users", function(){
                var response = config(server)
                                        .withVerb('put')
                                        .forUrl('/users');
                
                expect(response).toBe(true);                
        });
        
        it("maps to /users/:id", function(){
                var response = config(server)
                                .withVerb('get')
                                .forUrl('/users/:id');
                                
                 expect(response).toBe(true);                         
        });  
        
        it("maps to delete /users", function(){
                var response = config(server)
                                .withVerb('delete')
                                .forUrl('/users');
                                
                expect(response).toBe(true);                                        
        });      
});