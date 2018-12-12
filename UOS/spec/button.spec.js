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
	
	it('renders button with css class', function(){
		let button = UOS.Controls.createButton({cssClass:'css-class'});
		
		const result = button.render();
		
		expect(result).toBe("<button class='css-class'></button>");
	});
	
	it('renders button with style', function(){
		let button = UOS.Controls.createButton({style:'a-style'});
		
		const result = button.render();
		
		expect(result).toBe("<button style='a-style'></button>");
	});
	
	it('renders disabled button', function(){
		let button = UOS.Controls.createButton();
		button.disable();
		
		const result = button.render();
		
		expect(result).toBe('<button disabled></button>');
	});
	
	it('renders enabled button', function(){
		let button = UOS.Controls.createButton({name:'btn-save'});
		button.disable();
		button.enable();
		
		const result = button.render();
		
		expect(result).toBe("<button name='btn-save'></button>");
	});
});