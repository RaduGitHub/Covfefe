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
import { useHistory } from "react-router-dom";
import { withRouter } from 'react-router';
import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';

export class ProductPage extends Component {

    constructor() {
        super();

        this.state = {
            products: [],
            isAuthenticated: false,
            role: null,
            postId: 0
        };
    }

    deleteProduct(id, price) {
        console.log(this.state.products.productId);
        /*axios.delete('https://localhost:44333/api/Products', this.state.products.productId, {
            headers: {
                'Authorization': 'authorizationToken'
            }
        });*/

        fetch('https://localhost:44333/api/Products/' + this.state.products.productId, { method: 'DELETE' })
            .then(() => this.setState({ status: 'Delete successful' }));

        this.props.history.push('/');
    }

    addToCart(id, price) {
        console.log(id);
        console.log(price);
        console.log(this.state.role.sub);


        var cartItem =
        {
            
            "UserId": this.state.role.sub,
            "ProductID": id,
            "Quantity": 1,
            "Bought": false,
            "TotalPrice": price
        }


        console.log(cartItem);


        return axios.post('https://localhost:44333/api/Carts', cartItem, {
            headers: {
                'Content-Type': 'application/json'
            }
            })
            .then(function (response) {
                console.log(response)
            })
            .catch(function (error) {
                console.log(error.response);
                console.log(error.request);
                console.log(error.message);
            });
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
        console.log("abecedar");
        console.log(this.props.location.state.fromNotifications);
        return axios.get('https://localhost:44333/api/Products/' + this.props.location.state.fromNotifications)
            .then((res) => {
                this.setState({
                    products: res.data
                })
            });
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
        console.log("petre");
    }

    async populateState() {
        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            isAuthenticated,
            role: user
        });
        console.log(user);
    }

    render() {
        const rol = this.state.role;
        return (
            <body>
                <div class="product">
                    <div class="container">
                        <div class="row">
                            <h4 class="page-header">
                                {this.state.products.name}
                            </h4>
                        </div>
                        <div>
                            <img src="C:\Users\radum\Desktop\yap.jpg" alt="" />
                        </div>
                        Score: 
                        <div >
                            {this.state.products.score}
                        </div>
                        Description:
                        <div>
                             {this.state.products.description}
                        </div>
                        <div>
                            <button onClick={() => this.addToCart(this.state.products.productId, this.state.products.price)}>
                                Add to cart!
                            </button>
                        </div>
                        <div>
                            <button onClick={() => this.deleteProduct(this.state.products.productId)}>
                                Delete Item!
                            </button>
                        </div>
                    </div>
                </div>
             </body>
        );
    }
}
