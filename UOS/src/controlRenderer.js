(function(UOS){
	UOS.ControlRenderer = function ControlRenderer(){
		const errorMessage = 'There is no configuration';
		function render(configuration){
			if(!configuration){
				throw new Error(errorMessage);
			}
			throw 'not implemented';
		}
		
		return {
			render: render
			errorMessage: errorMessage
		}
	};
})(UOS)