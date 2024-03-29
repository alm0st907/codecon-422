import React, { Component } from "react";
import {
  Collapse,
  Button,
  Form,
  FormGroup,
  Navbar,
  Label,
  Input,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem
} from "reactstrap";
import { Link } from "react-router-dom";

/*Grabbed from: https://reactstrap.github.io/components/navbar/*/
export default class Navigation extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isOpen: false,
      loading: true /*used for loading splash*/,
      modal: false
    };
    this.toggle = this.toggle.bind(this);
    this.toggleModal = this.toggleModal.bind(this);
  }

  toggle() {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }

  componentDidMount() {
    setTimeout(() => this.setState({ loading: false }), 500); /*1.5 seconds*/
  }

  toggleModal() {
    this.setState(prevState => ({
      modal: !prevState.modal
    }));
  }

  render() {
    const { loading } = this.state;
    return (
      <div>
        <Navbar color="dark" dark expand="md">
          {" "}
          {/*md is medium*/}
          <NavbarToggler onClick={this.toggle} data-toggle="collapsed" />
          <Collapse
            isOpen={this.state.isOpen}
            style={{ float: "right" }}
            navbar
          >
            <Nav className="ml-auto" navbar>
              <UncontrolledDropdown nav inNavbar>
                <DropdownToggle nav caret>
                  Menu
                </DropdownToggle>
                <DropdownMenu right>
                  <DropdownItem tag={Link} to="/Issues">
                    Create Tasks
                  </DropdownItem>
                  <DropdownItem divider />
                  <DropdownItem tag={Link} to="/issueview">
                    Task Only View
                  </DropdownItem>
                  <DropdownItem divider />
                  <DropdownItem tag={Link} to="/Main">
                     Main Page
                  </DropdownItem>
                  <DropdownItem divider />
                </DropdownMenu>
              </UncontrolledDropdown>
              <UncontrolledDropdown nav inNavbar>
                <DropdownToggle nav caret>
                  fake-username
                </DropdownToggle>
                <DropdownMenu right>
                  <DropdownItem tag={Link} to="/">
                    Log out
                  </DropdownItem>
                </DropdownMenu>
              </UncontrolledDropdown>
            </Nav>
          </Collapse>
        </Navbar>
      </div>
    );
  }
}
