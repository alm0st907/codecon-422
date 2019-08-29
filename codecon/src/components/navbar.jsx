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
          <NavbarBrand id="grad1" href="#home">
            Test
          </NavbarBrand>
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
                  <DropdownItem onClick={this.toggleModal}>B</DropdownItem>

                  <DropdownItem>A</DropdownItem>
                  <DropdownItem>B</DropdownItem>
                </DropdownMenu>
              </UncontrolledDropdown>
              <UncontrolledDropdown nav inNavbar>
                <DropdownToggle nav caret>
                  Menu
                </DropdownToggle>
                <DropdownMenu right>
                  <DropdownItem>A</DropdownItem>
                  <DropdownItem>B</DropdownItem>
                  <DropdownItem divider />
                  <DropdownItem>CD</DropdownItem>
                </DropdownMenu>
              </UncontrolledDropdown>
            </Nav>
          </Collapse>
        </Navbar>
      </div>
    );
  }
}
