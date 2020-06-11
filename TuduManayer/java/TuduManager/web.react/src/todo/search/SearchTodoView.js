import React from 'react';
import { Spinner } from '../../Spinner';
import { createSearchTodoPresenter } from './SearchTodoPresenter';

export class SearchTodoView extends React.Component {

    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
            searchText: '',
            todos: [],
            errorMessage: ''
        }
    }

    presenter = createSearchTodoPresenter(this);

    render(){
        return (
                <div>
                    <Spinner show={this.state.showSpinner}/>
                    <input type='text' onChange={this.onSearchTextChange}/> <button onClick={this.search}>Search</button>
                    <p>{this.state.errorMessage}</p>
                </div>);
    }

    onSearchTextChange = (event) => {
        this.setState({ searchText: event.target.value });
    }

    search = () => {
        this.presenter.search(this.state.searchText);
    }

    showInternalServerError = () => {
        throw 'not implemented';
    }

    showErrors = (errors) => {
        throw 'not implemented';
    }

    showTodos = (todos) => {
        this.setState({ todos });
    }
}

export function createSearchTodoView(){
    return new SearchTodoView();
}