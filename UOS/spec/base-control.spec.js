describe('BaseControl', function(){
	var baseControl;

	beforeEach(function(){
		baseControl = new UOS.Controls.BaseControl();
	});
	
	it('throws an error if there is a error in configuration', function(){
		expect(function(){ controlRenderer.renderControl();}).toThrow(new Error(baseControl.configurationErrorMessage));
	});
	
	it('throws an error if there is no tag field in configuration', function(){
		const configuration = {};
		expect(function(){ baseControl.renderControl(configuration);}).toThrow(new Error(baseControl.tagConfigurationErrorMessage));
	});
});