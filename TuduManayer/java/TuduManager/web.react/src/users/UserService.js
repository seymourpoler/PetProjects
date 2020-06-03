export function UserService(){
    let self = this;

    self.find = async function (){
    const url = '/api/users';
    const response = await fetch(url);
    if(response.status === 500){
        return {statusCode: response.status};
    }
    const users = await response.json();
    return {
        statusCode: response.status,
        users}
    }
}

export function createUserService(){
    return new UserService();
}