import React from 'react';
import { Spinner } from '../../Spinner';

export class EditTodoView extends React.Component {
    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
            errorMessage: ''
        }
    }

    render(){
        return (<div>
            <Spinner show={this.state.showSpinner} />
        </div>);
    }

    cleanMessages = () => {
        throw 'not implemented';
    }

    showSpinner = () => {
        throw 'not implemented';
    }

    showInternalServerError = () => {
        throw 'not implemented';
    }

    showErrors = (errors) => {
        throw 'not implemented';
    }

    showUpdatedTodoMessage = () => {
        throw 'not implemented';
    }
}

export function createEditTodoView(){
    return new EditTodoView();
}