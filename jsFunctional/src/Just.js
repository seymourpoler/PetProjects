function Just(value){
	this.getValue = function(){
		return value;
	};
	
	this.bind = function(func){
		return new MayBe(func(value));
	};
}