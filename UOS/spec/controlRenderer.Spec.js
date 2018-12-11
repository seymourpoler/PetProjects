describe('Control Renderer', function(){
	var controlRenderer;

	beforeEach(function(){
		controlRenderer = new UOS.ControlRenderer();
	});

	it('throws an error if there is a error in configuration', function(){
		expect(function(){ controlRenderer.render();}).toThrow(new Error(controlRenderer.configurationErrorMessage));
	});
	
	it('throws an error if there is no tag field in configuration', function(){
		const configuration = {};
		expect(function(){ controlRenderer.render(configuration);}).toThrow(new Error(controlRenderer.tagConfigurationErrorMessage));
	});

	it('renders simple control', function(){
		const result = controlRenderer.render({tag: 'label'});

		expect(result).toBe('<label></label>');
	});

	it('renders id control', function(){
		const result = controlRenderer.render({tag: 'label', id:'control-id'});

		expect(result).toBe("<label id='control-id'></label>");
	});
});