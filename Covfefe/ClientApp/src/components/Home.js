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

export class Home extends Component {
    state = {
        Type: null
    };

    loadData = () => {
        this.setState({ loading: true });
        console.log("abecedar");
        return axios.get('https://localhost:44333/api/ProductTypes')
            .then((res) => {
                this.setState({
                    Type: res.data
            });
            })

       
    }

    async componentDidMount() {
        this.loadData();

        this.setState({ loading: false });
    }

    render() {
        if (this.state.loading) {
            return <div>loading...</div>;
        }

        if (!this.state.Type) {
            return <div>didn't get a person</div>;
        }
        return (
            <div>
                <div>
                    Categories:
                </div>
                <div>
                    <Link to={{
                        pathname: '/GetProductByCategory',
                        state: {
                            fromNotifications: "All"
                        }
                    }}>All</Link>
                </div>
                {this.state.Type.map(i =>
                    <div><Link to={{
                        pathname: '/GetProductByCategory',
                        state: {
                            fromNotifications: i.type
                        }
                    }}>{i.type}</Link></div>
                )}
            </div>
            
        );
    }
}
