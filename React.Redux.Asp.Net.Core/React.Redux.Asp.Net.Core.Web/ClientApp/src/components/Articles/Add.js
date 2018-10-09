import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Factory } from './Actions';
import ActionTypes from './Actions.types';

class Add extends Component {

    constructor(props) {
        super(props);
        this.actions = Factory(this.props.dispatch);
    }

    addTitle = () => {
        const title = document.getElementById('txtTitle').value;
        this.actions.addArticle({ title });
    };

    render() {
        let result = '';
        if (this.props.type === ActionTypes.ShowErrors && this.props.errors && Array.isArray(this.props.errors)) {
            result = this.props.errors.map((error, index) => {
                return (<p key={index}> {error.fieldId} : {error.errorCode} </p>);
            });
        }
        
        return (
            <div>
                <p>title:
                    <input type='text' id='txtTitle' />
                    <button id='btnAdd' onClick={this.addTitle}>Add</button>
                    <label>{ result }</label>
                </p>
            </div>
            );
    }
} 

export default connect()(Add);