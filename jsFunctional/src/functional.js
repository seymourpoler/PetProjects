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

//source: http://blog.carbonfive.com/2015/01/14/gettin-freaky-functional-wcurried-javascript/
function curry(fx) {
  var arity = fx.length;

  return function f1() {
    var args = Array.prototype.slice.apply(arguments);
    if (args.length >= arity) {
      return fx.apply(null, args);
    }    
    return function f2() {
	    var args2 = Array.prototype.slice.apply(arguments);
	    return f1.apply(null, args.concat(args2)); 
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