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
        return await buildResultFrom(response);
		                                      	
	}

    self.put = async (url, entity) => {
        const response = await fetch(url, {
            method: 'PUT',
            cache: 'no-cache',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify(entity)
        });
        return await buildResultFrom(response);
    }

    async function buildResultFrom(response){
        const body = await buildBody(response);
        return {
            statusCode: response.status,
            body
        }
    }

    async function buildBody(response){
        try{
            return await response.json();
        }catch{
            return {};
        }
    }
}

export function createHttp(){
	return new Http();
}
