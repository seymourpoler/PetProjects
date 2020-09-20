const createUnCooked = require('./UnCooked');
const createRaw = require('./Raw');
const createMediumRaw = require('./MediumRaw');
const createMedium = require('./Medium');
const createWellDone = require('./WellDone');

function createSteak(){
    let self = {};
    let doneness = createUnCooked();
    let currentTemperature = 0;

    self.getDoneness = function(){
        return doneness.getDoneness();
    };

    self.addTemperature = function(temperatue){
        currentTemperature += temperatue;
        updateDoneness();

        function updateDoneness(){
            if(currentTemperature < 100){
                doneness = createRaw();
                return;
            }
            if(currentTemperature < 130){
                doneness = createMediumRaw();
                return;
                
            }
            if(currentTemperature < 160){
                doneness = createMedium();
                return;
            }
            return doneness = createWellDone();
        }
    };

    self.getTemperature = function(){
        return currentTemperature;
    };

    return self;
}

module.exports = createSteak;
