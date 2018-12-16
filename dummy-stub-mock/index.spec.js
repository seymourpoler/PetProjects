describe('dummy, stub and mock', function(){

	it('shows a dummy', function(){
		const aDummy = {};

		const sut = new Sut(aDummy);
		
		expect(sut instanceof Sut).toBeTruthy();
	});

	it('shows a stub', function(){
		const clientValue = 24;
		const aStub = { getValue: function(){return clientValue;} };
		const sut = new Sut(aStub);

		const result = sut.getValue();

	});
});