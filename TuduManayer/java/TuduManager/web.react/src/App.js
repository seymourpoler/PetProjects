import React, { Component } from 'react';
import './App.css';
import Home from './Home';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { UserView } from './users/UserView';
import { SearchTodoView } from './todo/search/SearchTodoView';

class App extends Component {
  render() {
    return (
      <Router>
        <Switch>
          <Route path='/' exact={true} component={Home}/>
          <Route path='/users' exact={true} component={UserView}/>
          <Route path='/search' exact={true} component={SearchTodoView}/>
        </Switch>
      </Router>
    )
  }
}

export default App;