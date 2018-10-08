import React, { Component } from 'react';
import { connect } from 'react-redux';

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
        return (
            <div>
                <p>title:
                    <input type='text' id='txtTitle' />
                    <button id='btnAdd' onClick='this.addTitle' />
                </p>
            </div>
            );
    }
} 

export default connect()(Add);