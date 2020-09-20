const Doneness = require('./Doneness');

function createRaw(){
    let self = {};

    self.getDoneness = function(){
        return Doneness.Raw;
    };

    return self;
}

module.exports = createRaw;