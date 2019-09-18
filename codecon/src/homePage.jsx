import React, {Component} from "react";
import {
    Container,
    Col,
    Row,
    Form,
    FormGroup,
    FormText,
    FormFeedback,
    Label,
    Input,
    Button
} from "reactstrap";
import {Link} from "react-router-dom";
import "./homePage.css";

export default class Home extends Component {
    render() {
        return (
            <div>
                <div style={
                    {
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                        height: "40vh"
                    }
                }>
                    <h1 id="grad1">
                        CodeCon Issue Tracker</h1>
                </div>
                <div style={
                    {
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                        height: "20vh"
                    }
                }>
                    {" "}
                    <Button tag={Link}
                        to="/login"
                        id="signin"
                        color="success"
                        size="lg">
                        Login
                    </Button>
                    <Button id="register"
                        tag={Link}
                        color="warning"
                        size="lg"
                        to="/register">
                        Register
                    </Button>
                    {" "} </div>
            </div>
        );
    }
}
