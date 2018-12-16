describe('dummy, stub and mock', function(){
	it('show a dummy', function(){
		const aDummy = {};

		const sut = new Sut(aDummy);
		
		expect(sut instanceof Sut).toBeTruthy();
	});
});