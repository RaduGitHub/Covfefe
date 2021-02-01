import React, { Component } from 'react';


export class ViewPTypes extends Component {

    state = {
        loading: true,
        Type: null
    };

    async componentDidMount() {
        const url = "https://localhost:44333/api/ProductTypes";
        const response = await fetch(url);
        const data = await response.json();
        this.setState({ Type: data, loading: false });
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

                {this.state.Type.map((i) => (<div key={i.productTypeId}> {i.type}</div>))}
                {console.log(this.state.Type.length)}

            </div>
        );
        
    }
}