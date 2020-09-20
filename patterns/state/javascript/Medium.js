const Doneness = require('./Doneness');

function createMedium(){
    let self = this;

    self.getDoneness = function(){
        return Doneness.Medum;
    }

    return self;
}

module.exports = createMedium;