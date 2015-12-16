function MayBe(value){
	if(value == null || value == undefined){
		return new Nothing();
	}
	return new Just(value);
}