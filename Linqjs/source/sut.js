Array.prototype.count = function() {
  return this.length;
};

Array.prototype.sum = function(){
  var result = 0;
  for (var count = 0; count < this.length; count++) {
	  if(typeof(this[count]) === 'number'){
		result = result + this[count];
	  }
  };
  return result;
}

Array.prototype.take = function(position) {
	if(position > this.count()){
		return [];
	}

	return this.slice(0, position);
};

Array.prototype.where = function(condition){
	var result = [];
	for(var count = 0; count < this.count(); count++){
		if(condition(this[count])){
			result.push(this[count]);
		}
	}
	return result;	
}

Array.prototype.union = function(array){
	var result = [];
	for(var count = 0; count < this.count(); count++){
		if(condition(this[count])){
			result.push(this[count]);
		}
	}
	return result;	
}

exports.remove = function(){};
