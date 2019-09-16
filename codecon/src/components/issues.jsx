import React, { Component } from "react";
import {
  Container,
  Col,
  Form,
  FormGroup,
  FormText,
  Label,
  Input,
  Button
} from "reactstrap";
import { Link } from "react-router-dom";
import { async } from "q";
import "./issues.css";
export default class IssueInfo extends Component {
  constructor(props) {
    super(props);
    this.state = {
      issueName: "",
      issueDate: "",
      issueDescription: ""
    };
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  handleInputChange = async event => {
    const { target } = event;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const {
      name
    } = target; /*this directly correlates to the name of each input*/
    await this.setState({
      [name]: value
    });
  };

  submitForm(e) /*if event isnt handled explicitly, do not do the default*/ {
    e.preventDefault();
    console.log(`issueName: ${this.state.issueName}`);
    console.log(`issueDate: ${this.state.issueDate}`);
    console.log(`issueDescription: ${this.state.issueDescription}`);
  }

  render() {
    const { issueName, issueDate, issueDescription } = this.state;
    return (
      <div className="Issues">
        <h3>Issue</h3>
        <Form className="issueInfo" onSubmit={e => this.submitForm(e)}>
          {" "}
          {/*User's login information contained within this form*/}
          <Col>
            <FormGroup>
              {" "}
              {/*Wraps form control with proper spacing and label/helptext/validation STATE https://react-bootstrap.github.io/components/forms/ */}
              <Label>Issue Name</Label>
              <Input
                type="string"
                name="issueName"
                id="issueName"
                placeholder="Issue Name"
                value={issueName}
                onChange={e => {
                  this.handleInputChange(e);
                }}
              />{" "}
              {/*name field used in JS*/}
            </FormGroup>
          </Col>
          <Col>
            <FormGroup>
              {" "}
              <Label>Issue Date</Label>
              <Input
                type="date"
                /*masking*/ name="issueDate"
                id="issueDate"
                placeholder="MM/DD/YYYY"
                value={issueDate}
                onChange={e => {
                  this.handleInputChange(e);
                }}
              />{" "}
              {/*name field used in JS*/}
            </FormGroup>
          </Col>
          <Col>
            <FormGroup>
              {" "}
              <Label>Issue Description</Label>
              <Input
                type="textarea"
                /*masking*/ name="issueDescription"
                id="issueDescription"
                placeholder="Description of the issue"
                value={issueDescription}
                onChange={e => {
                  this.handleInputChange(e);
                }}
              />{" "}
              {/*name field used in JS*/}
            </FormGroup>
          </Col>
          <Col>
            <Button tag={Link} to="/scale" id="scale" color="success" size="md">
              Submit
            </Button>
          </Col>
        </Form>
      </div>
    );
  }
}
