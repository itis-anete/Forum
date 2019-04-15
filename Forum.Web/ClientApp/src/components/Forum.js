import React, {Component} from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class Forum extends Component{

    constructor (props) {
        super(props);
        this.state = { forums: [], loading: true };
    
        fetch('api/Forum/GetAllForums')
          .then(response => response.json())
          .then(data => {
            this.setState({ forums: data, loading: false });
        });
    }

    static renderForumsTable (forums) {
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
              {forums.map(forums =>
                <tr key={forums.name}>
                  <td><NavLink tag={Link} id={forums.id} className="text-dark" to={`/topic/${forums.id}`}>{forums.name}</NavLink></td>
                  <td>{forums.id}</td>
                  <td>{forums.description}</td>
                </tr>
              )}
            </tbody>
          </table>
        );
      }

    render(){
        let contents = Forum.renderForumsTable(this.state.forums);
    return (
      <div>
        <h1>Forums</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
    }
}