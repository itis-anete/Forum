import React, {Component} from 'react';

export class Topic extends Component{

    constructor (props) {
        super(props);
        this.state = { topics: [], loading: true, check:1 };
        fetch(`api/forum/topic/${this.props.params.forumsid}`)
          .then(response => response.json())
          .then(data => {
            this.setState({ topics: data.topics, loading: false });
        });
    }

    static renderTopicsTable (topics) {
        return (
          <table className='table table-striped'>
            <thead>
              <tr>
                <th>Name</th>
                <th>ID</th>
                <th>Description</th>
              </tr>
            </thead>
            <tbody>
              {topics.map(topics =>
                <tr key={topics.id}>
                  <td>{topics.id}</td>
                  <td>{topics.head}</td>
                  <td>{topics.text}</td>
                </tr>
              )}
            </tbody>
          </table>
        );
      }

    render(){
        let contents = Topic.renderTopicsTable(this.state.topics);
    return (
      <div>
        <h1>Topics</h1>
        {this.state.topics.id}
        {contents}
      </div>
    );
    }
}