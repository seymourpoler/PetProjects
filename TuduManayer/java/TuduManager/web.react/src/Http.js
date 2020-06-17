export function Http(){
    let self = this;
	
	self.get = async (url) => {
		const response = await fetch(url);
		//TODO: duplicated code extract method
		return {
			statusCode: response.status,
			body: await response.json()
		};
	};

	self.post = async (url) => {
		const response = await fetch(url, {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			}

		});

		//TODO: duplicated code extract method
		return {
			statusCode: response.statusCode,
			body: response.json()
		};                                      	
	}
}

export function createHttp(){
	return new Http();
}
