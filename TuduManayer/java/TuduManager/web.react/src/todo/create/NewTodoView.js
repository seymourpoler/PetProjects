import React from 'react';
import { Spinner } from '../../Spinner';
import { createNewTodoPresenter } from './NewTodoPresenter';

export class NewTodoView extends React.Component {

    constructor(props){
            super(props);

            this.state = {
                showSpinner: false,
                title: '',
                description: ''
            }
        }

    presenter = createNewTodoPresenter(this);

    render(){
        return(<div>
            <Spinner show={this.state.showSpinner}/>
            <input type='text' id='txtTitle' onChange={this.onTitleChanged} />
            <input type='text' id='txtDescription' onChange={this.onDescriptionChanged} />
            <button onClick={this.onSaveClicked}>Save</button>
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

    showInternalServerError = () => {
        throw 'not implemented';
    }

    showErrors = (errors) => {
        throw 'not implemented';
    }
}

export function createNewTodoView(){
    return new NewTodoView();
}
