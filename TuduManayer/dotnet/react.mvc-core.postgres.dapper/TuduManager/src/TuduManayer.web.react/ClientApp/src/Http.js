export function Http(){
    let self = this;

    self.get = async function(url) {
        const response = await fetch(url);
        return buildResultFrom(response);
    };


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
