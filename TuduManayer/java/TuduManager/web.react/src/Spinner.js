import React from 'react';

export class Spinner extends React.Component{

    state = {
        show: true
    };

    componentDidMount(){
        this.setState({show: this.props.show});
    }

    render(){
        if(this.state.show){
            return (<h1>Loading ... </h1>);
        }
        return null;
    }
}