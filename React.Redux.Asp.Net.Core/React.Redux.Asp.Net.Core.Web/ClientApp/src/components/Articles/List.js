import React, { Component } from 'react';
import { connect } from 'react-redux';
import Spinner from '../Spinner';
import Service from './Service';
import { showSpinner, hideSpinner } from './Actions';

class List extends Component {

    constructor(props) {
        super(props);
        this.service = new Service();
        this.loadArticles();
    }

    removeItem = (event) => {
        throw 'not implemented';
    };

    loadArticles = async () => {
        this.props.dispatch(showSpinner());
        const articles = await this.service.find();
        this.props.dispatch(articles);
        this.props.dispatch(hideSpinner());
    };

    render() {
        let result = 'No resuts';
        if (this.props.articles && Array.isArray(this.props.articles)) {
            result = this.props.articles.map((article, index) => {
                return (<a key={index} id={article.id} onClick={this.removeItem}> {article.title} </a>);
        });
    }

    return (
            <div>
                <Spinner show={this.props.showSpinner} />
                { result }
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        articles: state.articleReducer.articles,
        statusCode: state.articleReducer.statusCode,
        showSpinner: state.articleReducer.showSpinner,
        errors: state.articleReducer.errors
    };
};

export default connect(mapStateToProps)(List);