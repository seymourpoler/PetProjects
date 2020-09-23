const createUnCooked = require('./UnCooked');
const createRaw = require('./Raw');
const createMediumRaw = require('./MediumRaw');
const createMedium = require('./Medium');
const createWellDone = require('./WellDone');

function createSteak(){
    const initialTemperature = 0;
    let self = {};
    let doneness = createUnCooked();
    let currentTemperature = initialTemperature;

    self.getDoneness = function(){
        return doneness.getDoneness();
    };

    self.increaseTemperature = function(temperatue){
        currentTemperature += temperatue;
        updateDoneness();

    };

    self.decreaseTemperature = function(temperature){
        if(currentTemperature < temperature){
            currentTemperature = initialTemperature;
            return;
        }
        currentTemperature -= temperature
        updateDoneness();
    }

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

    self.getTemperature = function(){
        return currentTemperature;
    };

    return self;
}

module.exports = createSteak;
