const Doneness = require('./Doneness');

function createWellDone(){
    let self = this;

    self.getDoneness = function(){
        return Doneness.WellDone;
    }

    return self;
}

module.exports = createWellDone;