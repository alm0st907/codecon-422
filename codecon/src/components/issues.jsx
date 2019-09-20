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
      issueDescription: "",
      issueAssignee: "",
      issueDefconLevel: "",
      issueProject: ""
    };
    this.handleInputChange = this.handleInputChange.bind(this);
    this.postUp = this.postUp.bind(this);
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
    console.log(`issueAssignee: ${this.state.issueAssignee}`);
    console.log(`issueDefconLevel: ${this.state.issueDefconLevel}`);
    console.log(`issueDescription: ${this.state.issueDescription}`);
    console.log(`issueProject: ${this.state.issueProject}`);
  }

  postUp(e) {
    console.log("clicked the button");
    //need to fill out the data, populate the url with proper url for the action
    e.preventDefault();
    var data = {
      //username: "testname",
      projectName: this.state.issueProject,
      escalationValue: this.state.issueDefconLevel,
      assignedWorker: this.state.issueAssignee,
      taskName: this.state.issueName,
      description: this.state.issueDescription,
      issueDate: "12/01/2019"
    };

    fetch("https://localhost:44360/manageproject/CreateTask", {
      method: "post",
      body: JSON.stringify(data)
    });

    console.log(data);

    //if we get the return we like from the server, then handle the link redirect here
  }

  render() {
    const {
      issueName,
      issueDate,
      issueDescription,
      issueAssignee,
      issueDefconLevel
    } = this.state;
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
              <Label>Issue Assignee</Label>
              <Input
                type="string"
                /*masking*/ name="issueAssignee"
                id="issueAssignee"
                placeholder="John Doe"
                value={issueAssignee}
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
              <Label>Issue Defcon Level</Label>
              <Input
                type="number"
                /*masking*/ name="issueDefconLevel"
                id="issueDefconLevel"
                placeholder="1-5"
                value={issueDefconLevel}
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
            <Button
              tag={Link}
              to="/main"
              id="scale"
              color="success"
              size="md"
              onClick={this.postUp}
            >
              Submit
            </Button>
          </Col>
        </Form>
      </div>
    );
  }
}
