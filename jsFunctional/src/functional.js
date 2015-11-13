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

function pipe(data, secondFunction){
	return secondFunction(data);
}
