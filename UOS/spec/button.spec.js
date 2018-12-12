describe('Button', function(){
	it('renders simple button', function(){
		let button = UOS.Controls.createButton();
		
		const result = button.render();
		
		expect(result).toBe('<button></button>');
	});
	
	it('renders button with identifier', function(){
		let button = UOS.Controls.createButton({id:'btn-id'});
		
		const result = button.render();
		
		expect(result).toBe("<button id='btn-id'></button>");
	});
	
	it('renders button with name', function(){
		let button = UOS.Controls.createButton({name:'btn-name'});
		
		const result = button.render();
		
		expect(result).toBe("<button name='btn-name'></button>");
	});
	
	it('renders disabled button', function(){
		let button = UOS.Controls.createButton();
		button.disable();
		
		const result = button.render();
		
		expect(result).toBe('<button disabled></button>');
	});
});