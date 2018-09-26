import React, { Component } from 'react';

import CreateTodo from './CreateTodo';
import ListTodos from './ListTodos';

export default class FormTodos extends Component {
    render() {
        return (
            <div>
                <CreateTodo/>
                <br />
                <ListTodos />
            </div>
        );
    }
}

