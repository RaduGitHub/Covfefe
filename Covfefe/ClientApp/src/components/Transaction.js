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

export class Transaction extends Component {
    state = {
        carts: [],
        role: null,
        isAuthenticated: false

    };

    async componentDidMount() {
        console.log("Amajunsaici");
        this._subscription = authService.subscribe(() => this.populateState());
        await this.populateState();
        console.log(this.state.role);
        return axios.get('https://localhost:44333/api/Transactions/' + this.state.role.sub)
            .then((res) => {
                this.setState({
                    carts: res.data
                })
            });
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            role: user,
        });
        console.log(user);
    }

    render() {
        return (
            <div class="row">
                <div class="container">
                    Your current cart:
                    <table class="table table-striped text-center">
                        <tr>
                            <th>Product ID</th>
                            <th>Quantity</th>
                            <th>Price</th>
                        </tr>

                        {
                            this.state.carts.map(c =>
                                <tr>
                                    <td>{c.productId}</td>
                                    <td>{c.quantity}</td>
                                    <td>{c.totalPrice}</td>
                                </tr>)
                        }
                    </table>
                </div>
            </div>
        );
    }
}