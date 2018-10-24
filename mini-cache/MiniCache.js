function MiniCache(){
    let self = this;
    let values = {};

    self.set = function(key, value){
        if(isUndefinedOrStringEmpty(key) ||
            isUndefinedOrStringEmpty(value)){
            return;
        }
        values[key] = value;
    };

    self.contains = function(key){
        if(isUndefinedOrStringEmpty(key)){
            return false;
        }
        const value = values[key];
        return !isUndefinedOrStringEmpty(value);
    };

    function isUndefinedOrStringEmpty(element){
        return element === undefined || element === '' ;
    }

    self.get = function(key){
        if(key === undefined){
            return '';
        }
        return values[key];
    };

    self.remove = function(key){
        delete values[key];
    };
}

if(module && module.exports){
	module.exports	= MiniCache;
}
