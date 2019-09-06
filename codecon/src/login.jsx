import React, { Component } from "react";
import {
  Container,
  Col,
  Form,
  FormGroup,
  FormText,
  FormFeedback,
  Label,
  Input,
  Button
} from "reactstrap";
import { Link } from "react-router-dom";
import { async } from "q";
import "./login.css";

export default class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      password: "",
      validate_email: {
        emailState: ""
      },
      validate_password: {
        passwordState: ""
      }
    };
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  //These are just ways of adding some dynamic properties to the fields by auto changing warning from red to green
  validateEmail(e) {
    const email_re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/; /*https://github.com/alligatorio/Fancy-Form-Example/blob/master/src/App.js*/
    const { validate_email } = this.state;
    if (email_re.test(e.target.value)) {
      /*if match*/
      validate_email.emailState = "has-success";
    } else {
      validate_email.emailState = "has-danger";
    }
    this.setState({ validate_email });
  }
  validatePassword(e) {
    const password_re = new RegExp(
      "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8,})"
    ); /*requires 8 characters: 1 UC, 1 LC, 1 #, 1 Special https://www.thepolyglotdeveloper.com/2015/05/use-regex-to-test-password-strength-in-javascript/*/
    const { validate_password } = this.state;
    if (password_re.test(e.target.value)) {
      /*if match*/
      validate_password.passwordState = "has-success";
    } else {
      validate_password.passwordState = "has-danger";
    }
    this.setState({ validate_password });
  }

  /*https://medium.com/@ian.mundy/async-event-handlers-in-react-a1590ed24399*/
  /*https://reactjs.org/docs/forms.html refer to Handling Multiple Inputs*/
  handleInputChange = async event => {
    const { target } = event;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const { name } = target;
    await this.setState({
      [name]: value
    });
  };

  submitForm(e /*if event isnt handled explicitly, do not do the default*/) {
    e.preventDefault();
    console.log(`Email: ${this.state.email}`);
    console.log(`Password: ${this.state.password}`);
  }

  render() {
    const { email, password } = this.state;
    const isEnabled =
      this.state.validate_email.emailState === "has-success" &&
      this.state.validate_password.passwordState === "has-success";
    return (
      <div className="Login">
        Login
        <Form className="formLogin" onSubmit={e => this.submitForm(e)}>
          {" "}
          {/*User's login information contained within this form*/}
          <Col>
            <FormGroup>
              {" "}
              {/*Wraps form control with proper spacing and label/helptext/validation STATE https://react-bootstrap.github.io/components/forms/ */}
              <Label>Email</Label>
              <Input
                type="email"
                name="email"
                id="loginEmail"
                placeholder="user@mail.com"
                value={email}
                valid={this.state.validate_email.emailState === "has-success"}
                invalid={this.state.validate_email.emailState === "has-danger"}
                onChange={e => {
                  this.validateEmail(e);
                  this.handleInputChange(e);
                }}
              />{" "}
              {/*name field used in JS*/}
              <FormFeedback invalid>
                This must be a valid email address.
              </FormFeedback>
            </FormGroup>
          </Col>
          <Col>
            <FormGroup>
              <Label for="login_password">Password</Label>
              {/*masking*/}
              <Input
                type="password"
                name="password"
                id="loginPassword"
                placeholder="Password"
                value={password}
                valid={
                  this.state.validate_password.passwordState === "has-success"
                }
                invalid={
                  this.state.validate_password.passwordState === "has-danger"
                }
                onChange={e => {
                  this.validatePassword(e);
                  this.handleInputChange(e);
                }}
              />{" "}
              {/*name field used in JS*/}
              <FormFeedback invalid>
                Password requires at least: 1 lowercase, 1 uppercase, 1 number,
                and 1 special character.
              </FormFeedback>
              {/*TODO: set up user validation*/}
            </FormGroup>
          </Col>
          <Col>
            <Button
              disabled={!isEnabled}
              tag={Link}
              to="/websiteheader"
              id="signin"
              color="success"
              size="sm"
            >
              Login
            </Button>
            {/* This can be whatever, I just thought maybe we could do a git signup */}
            <Button id="register" color="link" size="sm">
              Register with Git
            </Button>
          </Col>
        </Form>
      </div>
    );
  }
}
