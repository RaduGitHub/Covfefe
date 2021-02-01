import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { ViewPTypes } from './components/ViewPTypes';
import { Carts } from './components/Carts';
import { ProductPage } from './components/ProductPage';
import { AddProduct } from './components/AddProduct';
import { Transaction } from './components/Transaction';
import { FinishTransaction } from './components/FinishTransaction';
import { GetProductByCategory } from './components/GetProductByCategory';
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { ApplicationPaths } from './components/api-authorization/ApiAuthorizationConstants';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/ViewPTypes' component={ViewPTypes} />
        <Route path='/ProductPage' component={ProductPage} />
        <Route path='/AddProduct' component={AddProduct} />
        <Route path='/FinishTransaction' component={FinishTransaction} />
        <Route path='/Carts' component={Carts} />
        <Route path='/Transaction' component={Transaction} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/GetProductByCategory' component={GetProductByCategory} />
        <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes} />
      </Layout>
    );
  }
}