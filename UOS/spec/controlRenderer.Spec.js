describe('Renderer', function(){
	it('throws an error if there is a error in configuration', function(){
		expect(UOS.ControlRenderer.render()).toThrow(new Error(UOS.ControlRenderer.errorMessage));
	});
});