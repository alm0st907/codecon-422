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
import "./register.css";

export default class Registration extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      password: "",
      confirm_password: "",
      validate_email: {
        emailState: ""
      },
      validate_password: {
        passwordState: ""
      },
      validate_confirmpassword: {
        passwordConfirmState: ""
      }
    };
    this.handleInputChange = this.handleInputChange.bind(this);
  }

  validateEmail(e) {
    const email_re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/; /*https://github.com/alligatorio/Fancy-Form-Example/blob/master/src/App.js*/
    const { validate_email } = this.state;
    if (email_re.test(e.target.value)) {
      /*if match*/ validate_email.emailState = "has-success";
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
      /*if match*/ validate_password.passwordState = "has-success";
      window.password_check = e.target.value;
    } else {
      validate_password.passwordState = "has-danger";
    }
    this.setState({ validate_password });
  }
  validateConfirmedPassword(e) {
    const { validate_confirmpassword } = this.state;
    if (e.target.value.toString() === window.password_check) {
      /*if match*/ validate_confirmpassword.passwordConfirmState =
        "has-success";
    } else {
      validate_confirmpassword.passwordConfirmState = "has-danger";
    }
    this.setState({ validate_confirmpassword });
  }
  /*RE taken from: https://www.oreilly.com/library/view/regular-expressions-cookbook/9781449327453/ch04s02.html*/

  /*https://medium.com/@ian.mundy/async-event-handlers-in-react-a1590ed24399*/
  /*https://reactjs.org/docs/forms.html refer to Handling Multiple Inputs*/
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
    console.log(`Email: ${this.state.email}`);
    console.log(`Password: ${this.state.password}`);
    console.log(`Confirmed Password: ${this.state.confirm_password}`);
  }

  postUp(e) {
    console.log("clicked the reg btn");
    //need to fill out the data, populate the url with proper url for the action
    e.preventDefault();
    var data = {
      //username: "testname",
      email: this.email,
      password: this.password,
      confirm_password: this.confirm_password
    };

    fetch("https://localhost:3000/manageproject/CreateUser", {
      method: "post",
      body: JSON.stringify(data)
    });

    console.log(data);
  }
  render() {
    const { email, password, confirm_password } = this.state;
    const isEnabled =
      this.state.validate_email.emailState === "has-success" &&
      this.state.validate_password.passwordState === "has-success" &&
      this.state.validate_confirmpassword.passwordConfirmState ===
        "has-success";
    return (
      <div className="Register">
        <h3>Register</h3>
        <Form className="Information" onSubmit={e => this.submitForm(e)}>
          {" "}
          {/*User's login information contained within this form*/}
          <Col>
            <FormGroup>
              {" "}
              {/*Wraps form control with proper spacing and label/helptext/validation STATE https://react-bootstrap.github.io/components/forms/ */}
              <Label>Email (this will be your username)</Label>
              <Input
                type="email"
                name="email"
                id="login_email"
                placeholder="Email"
                value={email}
                valid={this.state.validate_email.emailState === "has-success"}
                invalid={this.state.validate_email.emailState === "has-danger"}
                onChange={e => {
                  this.validateEmail(e);
                  this.handleInputChange(e);
                }}
              />{" "}
              {/*name field used in JS*/}
              <FormFeedback valid>Email looks good!</FormFeedback>
              <FormFeedback invalid>
                Something is wrong with that email!
              </FormFeedback>
            </FormGroup>
          </Col>
          <Col>
            <FormGroup>
              <Label for="password">Password</Label>
              <Input
                type="password"
                /*masking*/ name="password"
                id="login_password"
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
              <FormFeedback valid>Password looks good!</FormFeedback>
              <FormFeedback invalid>
                Make sure the password has 1 of each: uppercase, lowercase,
                number, and special character
              </FormFeedback>
              <FormText>
                Password Reqs: 1 Uppercase Character, 1 Lowercase Character, 1
                Number, 1 Special Character
              </FormText>
            </FormGroup>
          </Col>
          <Col>
            <FormGroup>
              <Label for="confirm_password">Confirm Password</Label>
              <Input
                type="password"
                /*masking*/ name="confirm_password"
                id="confirm_password"
                placeholder="Confirm Password"
                value={confirm_password}
                valid={
                  this.state.validate_confirmpassword.passwordConfirmState ===
                  "has-success"
                }
                invalid={
                  this.state.validate_confirmpassword.passwordConfirmState ===
                  "has-danger"
                }
                onChange={e => {
                  this.validateConfirmedPassword(e);
                  this.handleInputChange(e);
                }}
              />{" "}
              {/*name field used in JS*/}
              <FormFeedback valid>Password looks good!</FormFeedback>
              <FormFeedback invalid>
                Make sure the password is the same that you entered above!
              </FormFeedback>
            </FormGroup>
          </Col>
          <Col>
            <Button
              disabled={!isEnabled}
              tag={Link}
              to="/main"
              id="signup"
              color="success"
              size="sm"
            >
              Sign Up
            </Button>
          </Col>
        </Form>
      </div>
    );
  }
}
