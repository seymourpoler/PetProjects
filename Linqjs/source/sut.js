function removeElementInArray(number, vector){
	return vector.filter(function(element){
		return (element != number);
	});
}

exports.remove = removeElementInArray;
