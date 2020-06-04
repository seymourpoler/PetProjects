import React from 'react';
import { Spinner } from '../Spinner';
import { SearchTodoPresenter } './SearchTodoPresenter';

export class SearchTodoView extends React.Component  {

    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
            searchText: '',
            todos: [],
            errorMessage: ''
        }
    }

    presenter = createUserPresenter(this);

    render(){
        return (
                <div>
                    <Spinner show={this.state.showSpinner}/>
                    <input type='text' /> <a onclic>Search</a>
                    <p>{this.state.errorMessage}</p>
                </div>);
    }
}

export createSearchTodoView(){
    return new SearchTodoView();
}