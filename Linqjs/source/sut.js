Array.prototype.count = function() {
  return this.length;
};

Array.prototype.isEmpty = function(){
	return this.count() < 1;
}

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
	for(var count = 0; count < array.count(); count++){
		this.push(array[count]);
	}
	return this;	
}

Array.prototype.select = function(funct) {
	for (var count = 0; count < this.count(); count ++) {
		this[count] = funct(this[count]);
	};
	return this;
};

Array.prototype.remove = function(condition) {
	var result = [];
	for (var count = 0; count < this.count(); count ++) {
		if(condition(this[count])){
			result.push(this[count]);
		}
	};
	return result;
};

Array.prototype.add = function(element) {
	this.push(element);
	return this;
};

Array.prototype.clear = function(condition) {
	return [];
}

Array.prototype.orderAscending = function() {
	this.orderBy(function(x, y){
		return (x - y);
	});
	return this;
};

Array.prototype.orderDescending = function() {
	this.orderBy(function(x, y){
		return (y - x);
	});
	return this;
};

Array.prototype.orderBy = function(ordering) {
	return this.sort(ordering);
};

Array.prototype.first = function(condition) {
	var result = this.where(condition);
	if(result != []){
		return result[0];
	}
	return undefined;
};

Array.prototype.last = function() {
	if(this.isEmpty())
	{
		return undefined;
	}
	return this[this.count()-1];
};


Array.prototype.elementAt = function(position){
	return this[position];
}

Array.prototype.skip = function(number) {
	var result = [];
	var position = 0;
	this.forEach(function(element){
		if(position >= number){
			result.push(element);
		}
		position ++;
	});
	return result;
};

Array.prototype.getRange = function(position, length) {
	return this.skip(position)
				.take(length);
};

Array.prototype.isEqual = function(array) {
	if(this.count() != array.count()){
		return false;
	}
	for (var position = 0; position < this.count(); position++) {
		if(this[position] != array[position]){
			return false;
		}		
	};
	return true;
};

exports.remove = function(){};
