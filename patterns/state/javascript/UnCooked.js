const Doneness = require('./Doneness');

function createUnCooked(){
    let self = {};

    self.getDoneness = function(){
        return Doneness.UnCooked;
    };

    return self;
}

module.exports = createUnCooked;