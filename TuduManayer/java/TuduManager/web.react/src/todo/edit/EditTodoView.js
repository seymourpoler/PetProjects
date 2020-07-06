import React from 'react';
import { Spinner } from '../../Spinner';

export class EditTodoView extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
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

    onTitleChangedHandler = (event) => {
        throw 'not implemented';
    }

    onDescriptionChangedHandler = (event) => {
        throw 'not implemented';
    }

    onSaveClickedHandler = (event) => {
        throw 'not implemented';
    }

    onCancelClickedHandler = (event) => {
        throw 'not implemented';
    }
}

export function createEditTodoView(){
    return new EditTodoView();
}