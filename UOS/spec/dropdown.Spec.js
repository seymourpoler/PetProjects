describe('Drop down', function(){
	it('renders simple drop down', function(){
		let dropdown = UOS.Controls.createDropDown();
		
		const result = dropdown.render();
		
		expect(result).toBe('<select></select>');
	});
});