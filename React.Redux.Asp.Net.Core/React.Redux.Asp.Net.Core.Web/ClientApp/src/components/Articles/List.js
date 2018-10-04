import React, { Component } from 'react';
import { connect } from 'react-redux';
import Spinner from '../Spinner';
import { Factory } from './Actions';
import { OK, INTERNAL_SERVER_ERROR, BAD_REQUEST } from '../../HttpStatusCode.types';

class List extends Component {

    constructor(props) {
        super(props);
        this.actions = Factory();
        this.loadArticles();
    }

    removeItem = (event) => {
        const id = event.target.id;
        this.props.dispatch(this.actions.showSpinner());
        const result = this.actions.deleteArticle(id);
        this.props.dispatch(result);
        this.props.dispatch(hideSpinner());
        this.loadArticles();
    };

    loadArticles = async () => {
        this.props.dispatch(this.actions.showSpinner());
        const result = await this.actions.findArticles();
        this.props.dispatch(result);
        this.props.dispatch(this.actions.hideSpinner());
    };

    render() {
        let result = 'No results';
        if (this.props.statusCode === INTERNAL_SERVER_ERROR) {
            result = 'There is an internal server error';
        }
        if (this.props.statusCode === BAD_REQUEST && this.props.errors && Array.isArray(this.props.errors)) {
            result = this.props.errors.map((error, index) => {
                return (<p key={index}> {error.fieldId} : {error.errorCode} </p>);
            }); 
        }
        else if (this.props.statusCode === OK && this.props.articles && Array.isArray(this.props.articles)) {
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