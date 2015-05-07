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
	if(position > this.length){
		return [];
	}

	return this.slice(0, position);
};

exports.remove = function(){};
