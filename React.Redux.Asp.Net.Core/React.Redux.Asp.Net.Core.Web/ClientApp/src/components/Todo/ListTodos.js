import React, { Component } from 'react';
import { connect } from 'react-redux';
import { removeTodo } from './Actions';

const mapStateToProps = state => {
    return {
        todos: state.todoReducer.todos,
        count: state.counter
    };
};

class ListTodos extends Component {
    
    removeTodoItem = (event) => {
        const id = event.target.id;
        console.log('remove: ', id)
        this.props.dispatch(removeTodo(id));
    };

    render() {
        let result = 'List TODOS';
        if (this.props.todos && Array.isArray(this.props.todos)) {
            //result = (<p>{this.props.count}</p>);
            result = this.props.todos.map((todo, index) => {
                return (<a key={index} id={todo.id} onClick={this.removeTodoItem}> {todo.title} </a>);
            });
        }
        
        return (
            <div>
                { result }
            </div>
            );
    }
}

export default connect(mapStateToProps)(ListTodos);
