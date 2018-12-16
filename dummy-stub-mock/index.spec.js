describe('dummy, stub and mock', function(){

	it('shows a dummy', function(){
		const aDummy = {};

		const sut = new Sut(aDummy);
		
		expect(sut instanceof Sut).toBeTruthy();
	});

	it('shows a stub', function(){
		const collaboratorValue = 24;
		const aStub = { getValue: function(){return collaboratorValue;} };
		const sut = new Sut(aStub);

		const result = sut.getValue();

	});

	it('shows a mock', function(){
		const valueCollaborator = 17;
		const mockCollaborator = new MockCollaborator();
		const sut = new Sut(mockCollaborator);

		sut.collaborator_needed_method();

		expect(mockCollaborator.verify('doSomeThingVeryImportant')).toBeTruthy();
	});

	function MockCollaborator(value){
		let self = this;
		let calls = [];

		self.doSomeThingVeryImportant = function(){
			calls.push('doSomeThingVeryImportant');
		};

		self.verify = function(call){
			return calls.includes(call);
		}; 
	}
});