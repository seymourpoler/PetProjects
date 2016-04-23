function List(arrayData){
	var data = [];
	if(arrayData != undefined && arrayData != null){
		data = arrayData;
	}
	var self = this;

	this.getItem = function(position){
		return data[position];
	};

	this.count = function(){
		return data.length;
	};

	this.any = function(){
		return self.count() > 0;
	};

	this.sum = function(filter){
		var result = 0;
		var number;
		for (var position = 0; position < self.count(); position ++) {
			if(filter != 'undefined' && typeof(filter) === 'function'){
				result = result + filter(self.getItem(position));
			}
			else if(typeof(self.getItem(position)) === 'number'){
				result = result + self.getItem(position);
			}
		};
		return result;
	};

	this.take = function(numberOfElements){
		var result = new List([]);
		for (var position = 0; position < self.count() && position < numberOfElements; position ++) {
			result.add(self.getItem(position))
		};
		return result;
	};

	this.add = function(element){
		data.push(element);
		return new List(data);
	};

	this.addAt = function(position, element){
		var realPosition = position;	
		if(realPosition < 0){
			realPosition = 0;
		}
		if(realPosition >= self.count()){
			return self.add(element);
		}
		if(self.isEmpty()){
			return self.add(element);
		}
		var result = [];
		for(var index = 0; index < self.count(); index++){
			if(realPosition == index){
				result.push(element);
			}
			result.push(self.getItem(index));
		}
		return new List(result);
	};
	this.isEqual = function(list){
		if(self.count() != list.count()){
			return false;
		}
		for (var position = 0; position < self.count() ; position ++) {
			if(JSON.stringify(self.getItem(position)) != JSON.stringify(list.getItem(position))){
				return false;
			}
		}
		return true;
	};

	this.where = function(condition){
		var result = new List();
		var item;
		for (var position = 0; position < self.count(); position ++) {
			item = self.getItem(position);
			if(condition(item)){
				result.add(item);
			}
		}
		return result;
	};

	this.union = function(list){
		for (var position = 0; position < list.count(); position ++) {
			self.add(list.getItem(position));
		};
		return self;
	};

	this.reverse = function(){
		var result = new List();
		var item;
		for (var position = self.count() - 1; position >= 0; position --) {
			item = self.getItem(position);
			result.add(item)
		};
		return result;
	};

	this.select = function(func){
		var result = new List();
		var item;
		for (var position = 0; position < self.count(); position++) {
			item = func(self.getItem(position));
			result.add(item);
		};
		return result;
	};

	this.remove = function (condition) {
		var result = new List();
		for(var position = 0; position < self.count(); position ++){
			if(condition(self.getItem(position))){
				result.add(self.getItem(position));
			}
		}
		return result;
	};
	this.removeAt = function(position){
		if(self.isEmpty()){
			return self;
		}
		if(position >= self.count()){
			return self;
		}
		var result = new List([]);
		for(var index = 0; index < self.count(); index ++){
			if(index != position){
				result.add(self.getItem(index));
			}
		}
		return result;
	};

	this.clear = function(){
		data = [];
	};

	this.elementAt = function(position){
		return self.getItem(position);
	};

	this.isEmpty = function(){
		return self.count() == 0;
	};

	this.first = function(condition){
		if(typeof(condition) == 'undefined'){
			return self.getItem(0);
		}
		var item;
		for(var position = 0; position < self.count(); position ++){
			item = self.getItem(position);
			if(condition(item)){
				return item;
			}
		}
		return undefined;
	};

	this.last = function(condition){
		if(typeof(condition) == 'undefined'){
			var lasPosition = self.count() - 1;
			return self.getItem(lasPosition);
		}
		var item;
		for(var position = self.count()-1; position >= 0; position --){
			item = self.getItem(position);
			if(condition(item)){
				return item;
			}
		}
		return undefined;
	};

	this.orderAscending = function(){
		return self.orderBy(function(x, y){
			return (x - y);
		});
	};

	this.orderDescending = function() {
		return self.orderBy(function(x, y){
			return (y - x);
		});
	};

	this.orderBy = function(orderingFunction){
		return new List(data.sort(orderingFunction));
	};
	this.skip = function(number){
		var result = new List();
		var position = 0;
		for(var position = 0; position < self.count(); position++){
				if(position >= number){
				result.add(self.getItem(position));
			}
		}
		return result;
	};

	this.getRange = function(position, length){
		return self.skip(position)
				.take(length);
	};

	this.join = function(character){
		var result = "";
		if(typeof(character) == 'undefined'){
			character = '';
		}
		for(var position = 0; position < self.count(); position++){
			if(position + 1 < self.count()){
				result = result +  self.getItem(position) + character;
			}else{
				result = result + self.getItem(position);
			}
		}
		return result;
	};

	this.zip = function(list){
		return zip(self, list);

		function zip(listOne, listTwo){
			if(listOne.isEmpty()){
				return listTwo;
			}
			if(listTwo.isEmpty()){
				return listOne;
			}
			var headOne = listOne.first();
			var restOfOne = listOne.removeAt(0);
			var headTwo = listTwo.first();
			var restOfTwo = listTwo.removeAt(0);
			var result = zip(restOfOne, restOfTwo);
			return result.addAt(0,headTwo)
						 .addAt(0,headOne);
		}
	};

	this.distinct = function(){
		var result = new List();
		var element;
		for(var position = 0; position < self.count(); position++){
			element = self.getItem(position);
			if(isUniqueElementIn(result, element)){
				result.add(element);
			}
		}
		return result;

		function isUniqueElementIn(list, element){
				return list.where(function(x){ 
									return JSON.stringify(x) == JSON.stringify(element);
								}).isEmpty();
			}
	};

	this.indexOf = function(element){
		var result = -1;
		var item;
		for(var position=0; position<self.count(); position++){
			item = self.getItem(position);
			if(JSON.stringify(item) == JSON.stringify(element)){
				return position;
			}
		}
		return result;
	}
}
