function Nothing(){
	this.bind = function(func){
		return this;
	};
	
	this.isNothing = function(){
		return true;
	};
}