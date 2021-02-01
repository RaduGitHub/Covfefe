import axios from 'axios';
import React, { Component } from 'react';

import authService from './api-authorization/AuthorizeService';

export class AddProduct extends Component {

    constructor() {
        super();

        var today = new Date(),
            date = today.getDay() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear() + ' ' +
                today.getHours() + ':' + today.getMinutes() + ':' + today.getSeconds() + ' AM';

        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();

        this.state =
        {
            ProductTypeId: 0,
            Name: "",
            Description: "",
            NOComments: 0,
            UserId: "",
            DateCreated: today.toJSON(),
            Image: null,
            Price: 0,
            Stock: 0,
            Score: 0,
            role: null
        };
        this.onChange = this.onChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
        this.onDrop = this.onDrop.bind(this);
    }

    onChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    onDrop(event) {
        this.setState({
            Image: event.target.files[0]
        })
    }

    onSubmit(e) {
        e.preventDefault();

        var newProduct =
        {
            "ProductTypeId": parseInt(this.state.ProductTypeId),
            "Name": this.state.Name,
            "Description": this.state.Description,
            "NOComments": parseInt(this.state.NOComments),
            "UserId": this.state.role.sub,
            "DateCreated": this.state.DateCreated,
            "Image": null,
            "Price": parseInt(this.state.Price),
            "Stock": parseInt(this.state.Stock),
            "Score": parseInt(this.state.Score)
        }

        console.log(newProduct);

        axios.post('https://localhost:44333/api/Products', newProduct, {
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

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
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

            <div>
                <img src={this.state.Image} />

                <form onSubmit={this.onSubmit}>
                    <label> Name </label>
                    <div className="form-group">
                        <input
                            type="text"
                            className="form-control form-control-lg"
                            name="Name"
                            value={this.state.Name}
                            placeholder="Product Name"
                            onChange={this.onChange}
                        />
                    </div>

                    <label> Desciption </label>
                    <div className="form-group">
                        <input
                            type="text"
                            className="form-control form-control-lg"
                            name="Description"
                            value={this.state.Description}
                            placeholder="Description"
                            onChange={this.onChange}
                        />
                    </div>

                    <label> Price </label>
                    <div className="form-group">
                        <input
                            type="text"
                            className="form-control form-control-lg"
                            name="Price"
                            value={this.state.Price}
                            placeholder="Price"
                            onChange={this.onChange}
                        />
                    </div>

                    <label> Stock </label>
                    <div className="form-group">
                        <input
                            type="text"
                            className="form-control form-control-lg"
                            name="Stock"
                            value={this.state.Stock}
                            placeholder="Stock"
                            onChange={this.onChange}
                        />
                    </div>

                    <label> ProductTypeId </label>
                    <div className="form-group">
                        <input
                            type="text"
                            className="form-control form-control-lg"
                            name="ProductTypeId"
                            value={this.state.DiscountedPrice}
                            placeholder="ProductTypeId"
                            onChange={this.onChange}
                        />
                    </div>

                    <div>

                    </div>
                    <input
                        type="submit"
                        className="btn btn-primary btn-block mt-4"
                    />
                </form>
            </div>
        )
    }
}
