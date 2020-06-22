import React from 'react';
import { Spinner } from '../../Spinner';
import { createNewTodoPresenter } from './NewTodoPresenter';
import { ErrorMessages } from '../../ErrorMessages';

export class NewTodoView extends React.Component {

    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
            title: '',
            titleErrorMessage: '',
            description: '',
            descriptionErrorMessage: '',
            errorMessage: '',
            message: '',
        }
    }

    presenter = createNewTodoPresenter(this);

    render(){
        return(<div>
            <Spinner show={this.state.showSpinner}/>
            <p>Title: <input type='text' id='txtTitle' onChange={this.onTitleChanged} /></p>
            <p id='lblTitleErrorMessage'>{this.state.titleErrorMessage}</p>
            <p>Description: <input type='text' id='txtDescription' onChange={this.onDescriptionChanged} /></p>
            <p id='lblDescriptionErrorMessage'>{this.state.descriptionErrorMessage}</p>
            <button onClick={this.onSaveClicked}>Save</button>
            <button onClick={this.onCancelClicked}>Cancel</button>
            <p>{this.state.errorMessage}</p>
        </div>);
    }

    onTitleChanged = (event) => {
        this.setState({ title: event.target.value });
    }

    onDescriptionChanged = (event) => {
        this.setState({ description: event.target.value });
    }

    onSaveClicked = (event) => {
        this.presenter.save({
            title: this.state.title,
            description: this.state.description
        });
    }

    onCancelClicked = (event) => {
        this.presenter.cancel();
    }

    cleanMessages = () => {
        this.setState({ message: '' });
        this.setState({ errorMessage: '' });
        this.setState({ titleErrorMessage: '' });
        this.setState({ descriptionErrorMessage: '' });
    }

    showSpinner = () => {
        this.setState({ showSpinner: true });
    }

    hideSpinner = () => {
        this.setState({ showSpinner: false });
    }


    showInternalServerError = () => {
        this.setState({ errorMessage: ErrorMessages.InternalServerError });
    }

    showErrors = (errors) => {
        errors.forEach(error => {
            const message = ErrorMessages[error.errorCode];
            if(error.fieldId === 'title'){
                this.setState({ titleErrorMessage: message });
                return;
            }
            this.setState({ descriptionErrorMessage: message });
        });
    }

    showTodoCreated = () => {
        this.setState({ message: 'todo created' });
    }

    redirectToPageBefore = () => {
        this.props.history.push('/search');
    }
}

export function createNewTodoView(){
    return new NewTodoView();
}
