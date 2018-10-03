import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import FetchData from './components/FetchData';
import FormTodos from './components/Todo/FormTodos';
import FormArticles from './components/Articles/Form';

export default () => (
  <Layout>
    <Route exact path='/' component={Home} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata/:startDateIndex?' component={FetchData} />
        <Route path='/todos' component={FormTodos} />
        <Route path='/articles' component={FormArticles} />
  </Layout>
);
