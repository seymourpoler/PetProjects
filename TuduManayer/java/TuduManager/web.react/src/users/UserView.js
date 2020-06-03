import React from 'react';
import { Spinner } from '../Spinner';
import { createUserPresenter } from './UserPresenter';

export class UserView extends React.Component  {
    constructor(props){
        super(props);
        this.state = {
            showSpinner: false,
            users: [],
            errorMessage: ''
        }
    }

    presenter = createUserPresenter(this);

    

    componentDidMount = async () => {
        const users = await this.presenter.find();
        this.setState({ users });
    }

    showInternalServerError = () => {
        this.setState({errorMessage : 'Internal Server Error'});
    }

    cleanErrors = () => {
        this.setState({errorMessage : ''});
    }

    show = (users) => {
        this.setState({ users });
    }

    showSpinner = () => {
        this.setState({ showSpinner: true });
    }

    hideSpinner = () => {
        this.setState({ showSpinner: false });
    }
    render(){
        return (
            <div>Users
                <Spinner show={this.state.showSpinner}/>
                <label>{this.state.users}</label>
                <p>{this.state.errorMessage}</p>
            </div>);
    }
}

export function createUserView(){
    return new UserView();
}