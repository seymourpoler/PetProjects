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
                    <a href='#' onClick={this.onNewTodoClicked} > - new todo - </a>
                    <input type='text' onChange={this.onSearchTextChanged}/> <button onClick={this.onSearchClicked}>Search</button>
                    <p>{this.state.errorMessage}</p>
                    <p>{this.state.todos}</p>
                </div>);
    }

    onSearchTextChanged = (event) => {
        this.setState({ searchText: event.target.value });
    }

    onSearchClicked = (event) => {
        this.presenter.search(this.state.searchText);
    }

    showSpinner = () => {
        this.setState({ showSpinner: true });
    }

    hideSpinner = () => {
        this.setState({ showSpinner: false });
    }

    showInternalServerError = () => {
        this.setState({ errorMessage: 'There is an internal server error.' });
    }

    showTodos = (todos) => {
        this.setState({ todos });
    }

    onNewTodoClicked = () => {
        this.presenter.createNewTodo();
    }

    redirectToCreateNewTodo = () => {
        throw 'not implemented';
    }
}

export function createSearchTodoView(){
    return new SearchTodoView();
}