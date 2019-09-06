import React, { Component } from "react";
import {
  Collapse,
  Col,
  Row,
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
import styled from "styled-components";
import { Link } from "react-router-dom";

import TestNav from "./admin-navbar";

const StyledCol = styled(Col).attrs({
  className: "text-center",
  sx: "6"
})`
   {
    color: green;
  }
  .text-center {
    color: yellow;
  }
`;

/*Grabbed from: https://reactstrap.github.io/components/navbar/*/
export default class MainView extends Component {
  render() {
    return (
      <div>
        <TestNav></TestNav>

        <br />

        <Row>
          <StyledCol className="text-center" sx="6">
            Placeholder
          </StyledCol>
          <Col className="text-center" sx="6">
            Text
          </Col>
        </Row>
      </div>
    );
  }
}
