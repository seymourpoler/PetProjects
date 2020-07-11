import * as React from 'react';
import {createManageTodoPresenter} from "./ManageTodoPresenter";

export class ManageTodoView extends React.Component{

    constructor(props) {
        super(props);
        
        this.state = {
            showSpinner: false,
            searchText: '' ,
            errorMessage: ''
        }
    }
    
    presenter = createManageTodoPresenter(this);
    
    render() {
        return(<div>
            Search Todo
            <p>Search: <input type='text' id='search' onChange={this.onSearchChanged}/></p>
            <button onClick={this.onSearchClickedHandler}> search </button>
            <p id='errorMessage'>{this.state.errorMessage}</p>
            </div>);
    }

    cleanMessages = () => {
        this.setState({errorMessage: ''});
    }
    
    showSpinner = () => {
        this.setState({showSpinner:true});
    }

    showInternalServerErrorMessage = () => {
        this.setState({errorMessage: 'There is an internal server error.'});
    }
    
    show = (todos) => {
        throw 'not implemented';
    }

    onSearchChanged = (event) => {
        this.setState({searchText: event.target.value});
    }

    onSearchClickedHandler = () => {
        this.presenter.search(this.state.searchText);       
    }
}

export function createManageTodoView(){
    return new ManageTodoView({});
}