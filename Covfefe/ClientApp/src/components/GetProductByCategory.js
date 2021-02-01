import React, { Component } from 'react';
import axios from 'axios';
import { Container, Row, Col, Button } from 'reactstrap';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link,
    useRouteMatch
} from "react-router-dom";

import authService from './api-authorization/AuthorizeService';

export class GetProductByCategory extends Component {
    state = {
        products: [],
        role: null,
        isAuthenticated: false
    };

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
        console.log("abecedar");
        console.log(this.props.location.state.fromNotifications);
        return axios.get('https://localhost:44333/api/Products/?category=' + this.props.location.state.fromNotifications)
            .then((res) => {
                this.setState({
                    products: res.data
                })
            }); 
        console.log(this.props.location.state.fromNotifications);
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            role: user && user.role
        });
    }

    render() {


        return (
            <div class="row">
                <div class="container">
                    <table class="table table-striped text-center">
                        <tr>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Price</th>
                            <th>Stock</th>
                            <th>Score</th>
                            <th>Action</th>
                        </tr>

                            {
                                this.state.products.map(p =>
                                    <tr>
                                        <td>{p.name}</td>
                                        <td>{p.description}</td>
                                        <td>{p.price}</td>
                                        <td>{p.stock}</td>
                                        <td>{p.score}</td>
                                        <td><Link to={{
                                            pathname: '/ProductPage',
                                            state: {
                                                fromNotifications: p.productId
                                            }
                                        }}>View Product</Link></td>
                                    </tr>)
                            }
                        </table>
                </div>
            </div>
        );
    }
}
