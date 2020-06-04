import React from 'react';
import { Spinner } from '../Spinner';
import { SearchTodoPresenter } './SearchTodoPresenter';

export class SearchTodoView extends React.Component  {

    constructor(props){
        super(props);

        this.state = {
            showSpinner: false,
            todos: [],
            errorMessage: ''
        }
    }

    presenter = createUserPresenter(this);
}