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
  DropdownItem,
  Container
} from "reactstrap";
import styled from "styled-components";
import { Link } from "react-router-dom";

import AdminNav from "./admin-navbar";
import DefScale from "./scale";

// can do text align in either the attrs via reactstrap or in css proper below
const StyledCol = styled(Col).attrs({
  // className: "text-center",
  sx: "6"
})`
   {
    color: white;
    text-align: center;
  }
`;

const mainContainer = styled(Container).attrs({
  height: 500,
  width: 500
})`
  {
      display: flex
      flex-direction: 'column',
      justifyContent: 'center',
      alignItems: 'center'
  }
  `;

/*Grabbed from: https://reactstrap.github.io/components/navbar/*/
export default class MainView extends Component {
  render() {
    return (
      <div>
        <AdminNav></AdminNav>

        <br />

        <Row>
          <StyledCol>
            <DefScale></DefScale>
          </StyledCol>

          <StyledCol>Text</StyledCol>
        </Row>
      </div>
    );
  }
}
