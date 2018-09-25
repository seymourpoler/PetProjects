import React, { Component } from 'react';

import Create from './CreateTodo';
import List from './ListTodos';

export default class FormTodos extends Component {
    render() {
        return (
            <div>
                <Create/>
                <br />
                <List />
            </div>
        );
    }
}

