describe('Control Renderer', function(){
	var controlRenderer;

	beforeEach(function(){
		controlRenderer = UOS.Controls.createControlRenderer();
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

	it('renders control with identifier', function(){
		const result = controlRenderer.render({tag: 'label', id:'control-id'});

		expect(result).toBe("<label id='control-id'></label>");
	});

	it('renders control with name', function(){
		const result = controlRenderer.render({tag: 'label', name:'control-name'});

		expect(result).toBe("<label name='control-name'></label>");
	});

	it('renders control with css class', function(){
		const result = controlRenderer.render({tag:'div', cssClass:'css-class'});

		expect(result).toBe("<div class='css-class'></div>");
	});

	it('renders control with style', function(){
		const result = controlRenderer.render({tag:'a', style:'color:red;'});

		expect(result).toBe("<a style='color:red;'></a>");
	});

	it('renders disabled control', function(){
		const result = controlRenderer.render({tag:'a', disabled: true});

		expect(result).toBe("<a disabled></a>");
	});
	
});