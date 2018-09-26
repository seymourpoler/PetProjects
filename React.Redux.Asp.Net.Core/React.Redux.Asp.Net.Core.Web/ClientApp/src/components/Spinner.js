import React, { Component } from 'react';

export default class Spinner extends Component {
    render() {
        let result = '';
        if (this.props.show) {
            result = < p > loading ... </p >;
        }
        return (
            <div>
                { result }
            </div>
            );
    }
}