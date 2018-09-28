﻿import React, { Component } from 'react';
import { connect } from 'react-redux';

class List extends Component {

    removeItem = (event) => {
        throw 'not implemented';
    };

    render() {
        let result = 'No resuts';
        if (this.props.articles && Array.isArray(this.props.articles)) {
            result = this.props.articles.map((article, index) => {
                return (<a key={index} id={article.id} onClick={this.removeItem}> {article.title} </a> <br />);
            });
        }
        return (
            <div>
                { result }
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        articles: state.ArticleReducer.articles,
    };
};

export default connect(mapStateToProps)(List);