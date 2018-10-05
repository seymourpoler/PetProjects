import React, { Component } from 'react';
import { connect } from 'react-redux';
import Spinner from '../Spinner';
import { Factory } from './Actions';
import ActionTypes from './Actions.types';

class List extends Component {

    constructor(props) {
        super(props);
        this.actions = Factory(this.props.dispatch);
        this.actions.findArticles();
    }

    removeItem = (event) => {
        const id = event.target.id;
        this.actions.showSpinner();
        const result = this.actions.deleteArticle(id);
        this.props.dispatch(result);
        this.actions.hideSpinner();
        this.actions.findArticles();
    };

    render() {
        let result = 'No results';
        if (this.props.type === ActionTypes.ShowErrors && this.props.errors && Array.isArray(this.props.errors)) {
            result = this.props.errors.map((error, index) => {
                return (<p key={index}> {error.fieldId} : {error.errorCode} </p>);
            }); 
        }
        else if (this.props.type === ActionTypes.ShowArticles && this.props.articles && Array.isArray(this.props.articles)) {
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
        type: state.articleReducer.type,
        showSpinner: state.articleReducer.showSpinner,
        errors: state.articleReducer.errors
    };
};

export default connect(mapStateToProps)(List);