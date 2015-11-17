function map(arrayOfData, handler){
	var mappedResult = [];
	for (var position = 0; position < arrayOfData.length; position++) {
		mappedResult.push(handler(arrayOfData[position]));
	};
	return mappedResult;
}

function reduce(arrayOfData, initialValue, handler){
	var reducedResult = initialValue;
	for (var position = 0; position < arrayOfData.length; position++) {
		reducedResult = handler(reducedResult, arrayOfData[position]);
	}
	return reducedResult;
}

function filter(arrayOfData, handler){
	var filteredResult = [];
	for (var position = 0; position < arrayOfData.length; position++) {
		if(handler(arrayOfData[position])){
			filteredResult.push(arrayOfData[position]);
		}
	};
	return filteredResult;
}

function forEach(arrayOfData, handler){
	for (var position = 0; position < arrayOfData.length; position++) {
		handler(arrayOfData[position])
	};
}

function curry(func) {
  var argumentsLengthOfcurryfiedFunction = func.length;

  return function partialFunction() {
    var args = Array.prototype.slice.apply(arguments);
    if (args.length >= argumentsLengthOfcurryfiedFunction) {
      return func.apply(null, args);
    }    
    return function() {
	    var args2 = Array.prototype.slice.apply(arguments);
	    return partialFunction.apply(null, args.concat(args2)); 
    }
  };
}

function pipe(data, secondFunction){
	return secondFunction(data);
}

function PipeLine(){
	var registeredfunctions = [];
	var self = this;
	
	this.pipe = function(handler){
		registeredfunctions.push(handler);
		return self;
	};
	this.execute = function(params){
		var result = params;
		for(var position = 0; position < registeredfunctions.length; position++){
			result = registeredfunctions[position](result);
		}
		return result;
	};
}