import React, { Component } from 'react';
import { connect } from 'react-redux';
import Spinner from '../Spinner';
import Service from './Service';
import { showSpinner } from './Actions';

class List extends Component {

    constructor() {
        this.loadArticles();
    }

    removeItem = (event) => {
        throw 'not implemented';
    };

    loadArticles = () => {
        this.props.dispatch(showSpinner());
        this.props.dispatch(Service.find());
        this.props.dispatch(hideSpinner());
    };

    render() {
        <Spinner show={this.props.showSpinner} />

        let result = 'No resuts';
        if (this.props.articles && Array.isArray(this.props.articles)) {
            result = this.props.articles.map((article, index) => {
                return <a key={index} id={article.id} onClick={this.removeItem}> {article.title} </a>;
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
        showSpinner: state.ArticleReducer.statusCode,
        errors: state.ArticleReducer.errors
    };
};

export default connect(mapStateToProps)(List);