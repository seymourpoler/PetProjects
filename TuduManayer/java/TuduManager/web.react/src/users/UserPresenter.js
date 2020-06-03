import {createUserService} from './UserService';

export class UserPresenter{

    constructor(view, service){
        this.view = view;
        this.service = service;
    }

    find(){
        this.view.showSpinner();
        this.view.cleanErrors();
        const result = this.service.find();
        this.view.hideSpinner();
        if(result.statusCode === 500){
            this.view.showInternalServerError();
            return;
        }
        const users = result.users;
        this.view.show(users);
    }
}

export function createUserPresenter(view){
    const userService = createUserService();
    return new UserPresenter(view, userService);
}
