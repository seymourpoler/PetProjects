import React from 'react';
import { Spinner } from '../../Spinner';
import { createSearchTodoPresenter } from './SearchTodoPresenter';
import { ErrorMessages } from '../../ErrorMessages';

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
                    <button onClick={this.onNewTodoClicked} > new </button>
                    <input type='text' onChange={this.onSearchTextChanged}/><button onClick={this.onSearchClicked}> search </button>
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

    cleanMessages = () => {
        this.setState({errorMessage: ''});
    }


    showInternalServerError = () => {
        this.setState({ errorMessage: ErrorMessages.InternalServerError });
    }

    showTodos = (todos) => {
        this.setState({ todos });
    }

    onNewTodoClicked = () => {
        this.presenter.createNewTodo();
    }

    redirectToCreateNewTodo = () => {
        this.props.history.push("/new");
    }
}

export function createSearchTodoView(){
    return new SearchTodoView();
}