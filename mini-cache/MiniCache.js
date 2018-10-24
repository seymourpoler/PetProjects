function MiniCache(){
    let self = this;
    let values = {};

    self.set = function(key, value){
        if(key === undefined || value == undefined){return;}
        values[key] = value;
    };

    self.get = function(key){
        if(key === undefined){
            return '';
        }
        return values[key];
    };

    self.contains = function(key){
        if(key === undefined){
            return false;
        }
        values[key];
    };
}

module.exports = MiniCache;