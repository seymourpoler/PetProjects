export function Http(){
    let self = this;
	
	self.get = async (url) => {
   		const response = await fetch('GET', url);
		return {
			statusCode: response.statusCode,
			data: response.json()};
	}

}
