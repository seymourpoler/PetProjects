const Doneness = require('./Doneness');

function createMediumRaw(){
    let self = this;

    self.getDoneness = function(){
        return Doneness.MedumRaw;
    }

    return self;
}

module.exports = createMediumRaw;