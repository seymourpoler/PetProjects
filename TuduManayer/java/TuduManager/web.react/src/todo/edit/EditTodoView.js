import React from 'react';
import { Spinner } from '../../Spinner';

export class EditTodoView extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
            id: '',
            title: '',
            description: '',
            titleErrorMessage: '',
            errorMessage: ''
        }
    }

    render(){
        return (<div>
                <Spinner show={this.state.showSpinner} />
                <p>Title: <input type='text' id='title' onChange={this.onTitleChangedHandler} /></p>
                <p id='titleErrorMessage'>{this.state.titleErrorMessage}</p>
                <p>Description: <input type='text' id='description' onChange={this.onDescriptionChangedHandler} /></p>
                <button id='save' onClick={this.onSaveClickedHandler}></button>
                <button id='cancel' onClick={this.onCancelClickedHandler}></button>
                <p id='errorMessage'>{this.state.errorMessage}</p>
            </div>);
    }

    cleanMessages = () => {
        this.setState({
            titleErrorMessage: '',
            errorMessage: ''});
    }

    showSpinner = () => {
        this.setState({showSpinner: true});
    }

    hideSpinner = () => {
        this.setState({showSpinner: false});
    }

    showInternalServerError = () => {
        this.setState({errorMessage: 'There is an internal server error.'})
    }

    showErrors = (errors) => {
        throw 'not implemented';
    }

    showUpdatedTodoMessage = () => {
        throw 'not implemented';
    }

    redirectToSearchPage = () => {
        this.props.history.push('/search');
    }

    onTitleChangedHandler = (event) => {
        this.setState({ title: event.target.value });
    }

    onDescriptionChangedHandler = (event) => {
        this.setState({ description: event.target.value });
    }

    onSaveClickedHandler = (event) => {
        this.presenter.update({
            id: this.state.id,
            title: this.state.title,
            description: this.state.description
        })
    }

    onCancelClickedHandler = (event) => {
        this.presenter.cancel();
    }
}

export function createEditTodoView(){
    return new EditTodoView();
}