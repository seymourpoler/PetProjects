import React from 'react';
import { Spinner } from '../../Spinner';
import { createManageTodoPresenter } from './ManageTodoPresenter';
import { ErrorMessages } from '../../ErrorMessages';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table';

export class ManageTodoView extends React.Component {

    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
            searchText: '',
            todos: [],
            errorMessage: ''
        }
    }

    presenter = createManageTodoPresenter(this);

    btnEditTodo = (cell, row, enumObject, rowIndex) => {
        return (
        <button type="button"
            onClick={() => {
                    console.log('row: ', row);
                    this.presenter.editTodo(row.id);
                }
            }>
            edit
        </button>
      )
    }

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
                      <TableHeaderColumn dataField='button' dataFormat={this.btnEditTodo}
                                />
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
        this.props.history.push("/create");
    }

    redirectToEditTodo = (todoId) => {
        this.props.history.push("/todos/" + todoId);
    }
}

export function createManageTodoView(){
    return new ManageTodoView();
}