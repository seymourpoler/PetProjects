describe('BaseControl', function(){
	var baseControl;

	beforeEach(function(){
		baseControl = UOS.Controls.BaseControl();
	});
	
	it('throws an error if there is a error in configuration', function(){
		expect(function(){ controlRenderer.renderControl();}).toThrow(new Error(baseControl.configurationErrorMessage));
	});
});