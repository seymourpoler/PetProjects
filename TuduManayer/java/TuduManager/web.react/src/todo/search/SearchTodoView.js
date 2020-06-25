import React from 'react';
import { Spinner } from '../../Spinner';
import { createSearchTodoPresenter } from './SearchTodoPresenter';
import { ErrorMessages } from '../../ErrorMessages';
import {BootstrapTable, TableHeaderColumn} from 'react-bootstrap-table';

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
                    <button onClick={this.onNewTodoClickedHandler} > new </button>
                    <input type='text' onChange={this.onSearchTextChangedHandler}/><button onClick={this.onSearchClickedHandler}> search </button>
                    <p>{this.state.errorMessage}</p>
                    <BootstrapTable data={this.state.todos} striped hover>
                      <TableHeaderColumn isKey dataField='id'>ID</TableHeaderColumn>
                      <TableHeaderColumn dataField='title'>Title</TableHeaderColumn>
                  </BootstrapTable>
                </div>);
    }

    onSearchTextChangedHandler = (event) => {
        this.setState({ searchText: event.target.value });
    }

    onSearchClickedHandler = (event) => {
        this.presenter.search(this.state.searchText);
    }

    onNewTodoClickedHandler = () => {
        this.presenter.createNewTodo();
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

    redirectToCreateNewTodo = () => {
        this.props.history.push("/new");
    }
}

export function createSearchTodoView(){
    return new SearchTodoView();
}