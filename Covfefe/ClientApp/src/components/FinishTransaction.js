import axios from 'axios';
import React, { Component } from 'react';

import authService from './api-authorization/AuthorizeService';

export class FinishTransaction extends Component {

    constructor() {
        super();

        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();

        this.state =
        {
            Number: "",
            Holder: "",
            CCV: "",
            status: "",
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

        console.log(this.state.role.sub);

        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title: 'React Hooks PUT Request Example' })
        };
        fetch('https://localhost:44333/api/Carts/' + this.state.role.sub, requestOptions);

        //console.log(newProduct);

        /*axios.post('https://localhost:44333/api/Cart', newProduct, {
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
            });*/
    }

    componentDidMount() {
        this._subscription = authService.subscribe(() => this.populateState());
        this.populateState();
    }

    componentWillUnmount() {
        authService.unsubscribe(this._subscription);
    }

    async populateState() {

        const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
        this.setState({
            role: user
        });
        console.log(user);
    }

    render() {
        return (

            <div>
                <img src={this.state.Image} />

                <form onSubmit={this.onSubmit}>
                    <label> Number </label>
                    <div className="form-group">
                        <input
                            type="text"
                            className="form-control form-control-lg"
                            name="Number"
                            value={this.state.Number}
                            placeholder="Card Number"
                            onChange={this.onChange}
                        />
                    </div>

                    <label> Holder </label>
                    <div className="form-group">
                        <input
                            type="text"
                            className="form-control form-control-lg"
                            name="Holder"
                            value={this.state.Holder}
                            placeholder="Holder"
                            onChange={this.onChange}
                        />
                    </div>

                    <label> CCV </label>
                    <div className="form-group">
                        <input
                            type="text"
                            className="form-control form-control-lg"
                            name="CCV"
                            value={this.state.CCV}
                            placeholder="CCV"
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
