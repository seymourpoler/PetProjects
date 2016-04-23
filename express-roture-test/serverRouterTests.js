var config = require('./expressRouteTest');
var server = require('./server');

config(server)
        .withVerb('put')
        .forUrl('/users');
        
config(server)
        .withVerb('get')
        .forUrl('/users/:id');
        
config(server)
        .withVerb('delete')
        .forUrl('/users');