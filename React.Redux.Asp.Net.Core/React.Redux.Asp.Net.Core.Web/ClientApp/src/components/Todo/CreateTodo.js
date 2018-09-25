import React, { Component } from 'react';
import { connect } from 'react-redux';
import { addTodo } from './Actions';

class CreateTodo extends Component {

    AddTodo = (event) => {
        event.preventDefault();
        const title = document.getElementById('txtTitle').value;
        const description = document.getElementById('txtDescription').value;
        //this.props.dispatch(addTodo(
        //    {
        //        id: Math.random().toString(),
        //        title: title,
        //        description: description
        //    }));
        this.props.add({
            id: Math.random().toString(),
            title: title,
            description: description
        });
    };

    render() {
        return (
            <div>
                <p>Title: <input type='text' id='txtTitle' /></p>
                <p>Description: <input type='text' id='txtDescription' /></p>
                <button onClick={ this.AddTodo }>Add Todo</button>
            </div>
            );
    }
}

//const mapStateToProps = (state) => {
//    return state;
//};

const mapDispatchToProps = dispatch => {
    return {
        add: todo => {
            dispatch(addTodo(todo));
        }
    };
};

//export default connect(mapStateToProps, mapDispatchToProps)(CreateTodo);


const Create = connect(null, mapDispatchToProps)(CreateTodo);
export default Create;