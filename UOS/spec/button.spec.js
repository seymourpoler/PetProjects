describe('Button', function(){
	it('renders simple button', function(){
		let button = UOS.Controls.createButton();
		
		const result = button.render();
		
		expect(result).toBe('<button></button>');
	});
});