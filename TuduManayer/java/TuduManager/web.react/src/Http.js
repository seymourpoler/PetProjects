export function Http(){
    let self = this;
	
	self.get = async (url) => {
		const response = await fetch(url);
        return buildResultFrom(response);
	};

	self.post = async (url, entity) => {
		const response = await fetch(url, {
			method: 'POST',
            cache: 'no-cache',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
            body: JSON.stringify(entity)
		});
        return buildResultFrom(response);
		                                      	
	}

    function buildResultFrom(response){
        return {
            statusCode: response.status,
            body: response.json()
        }
    }
}

export function createHttp(){
	return new Http();
}
