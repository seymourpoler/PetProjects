import React, { Component } from 'react';
import { connect } from 'react-redux';
import Spinner from '../Spinner';

class List extends Component {

    removeItem = (event) => {
        throw 'not implemented';
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
        showSpinner: state.ArticleReducer.showSpinner
    };
};

export default connect(mapStateToProps)(List);