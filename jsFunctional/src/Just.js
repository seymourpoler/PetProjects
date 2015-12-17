function Just(value){
	this.getValue = function(){
		return value;
	};
	
	this.isNothing = function(){
		return false;
	};
	
	this.bind = function(func){
		return new MayBe(func(value));
	};
}