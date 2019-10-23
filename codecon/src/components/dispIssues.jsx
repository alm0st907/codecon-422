import React, { Component } from "react";
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
import { Link } from "react-router-dom";
import UserNavigation from "./user-navbar";

const taskStyle = {
  color: "white",
  listStyleType: "none",
  textAlign: "left"
};

const defconRank = {
  color: "white",
  textAlign: "center"
};

export default class DisplayIssues extends Component {
  constructor(props) {
    super(props);
    this.state = {
      error: null,
      isLoaded: false,
      items: []
    };
  }
  componentDidMount() {
    console.log("try fetch");
    fetch("https://localhost:5001/manageproject/getalltasks?projectname=Codecon")
      .then(res => res.json())
      .then(
        result => {
          this.setState({ isLoaded: true, items: result.items });
          console.log(result);
        },
        // Note: it's important to handle errors here
        // instead of a catch() block so that we don't swallow
        // exceptions from actual bugs in components.
        error => {
          this.setState({ isLoaded: true, error });
        }
      );
  }
  render() {
    const { error, isLoaded, items } = this.state;
    var esc1 = this.state.items.filter(x => x.escalationVal === 1);
    var esc2 = this.state.items.filter(x => x.escalationVal === 2);
    var esc3 = this.state.items.filter(x => x.escalationVal === 3);
    var esc4 = this.state.items.filter(x => x.escalationVal === 4);
    var esc5 = this.state.items.filter(x => x.escalationVal === 5);

    if (error) {
      return <div>Error: {error.message}</div>;
    } else if (!isLoaded) {
      return <div>Loading...</div>;
    } else {
      return (
        <div>
          <div style={defconRank}>
            DEFCON 1 Tasks
            <br />
            <ul style={taskStyle}>
              {esc1.map(item => (
                <li key={item.escalationVal}>
                  <br />
                  Task : {item.taskName}
                  <br />
                  Desc : {item.description}
                  <br />
                  Assignee : {item.assignee}
                  <br />
                  <br />
                </li>
              ))}{" "}
            </ul>
          </div>
          <div style={defconRank}>
            DEFCON 2 Tasks
            <br />
            <ul style={taskStyle}>
              {esc2.map(item => (
                <li key={item.escalationVal}>
                  <br />
                  Task : {item.taskName}
                  <br />
                  Desc : {item.description}
                  <br />
                  Assignee : {item.assignee}
                  <br />
                  <br />
                </li>
              ))}{" "}
            </ul>
          </div>
          <div style={defconRank}>
            DEFCON 3 Tasks
            <br />
            <ul style={taskStyle}>
              {esc3.map(item => (
                <li key={item.escalationVal}>
                  <br />
                  Task : {item.taskName}
                  <br />
                  Desc : {item.description}
                  <br />
                  Assignee : {item.assignee}
                  <br />
                  <br />
                </li>
              ))}{" "}
            </ul>
          </div>
          <div style={defconRank}>
            DEFCON 4 Tasks
            <br />
            <ul style={taskStyle}>
              {esc4.map(item => (
                <li key={item.escalationVal}>
                  <br />
                  Task : {item.taskName}
                  <br />
                  Desc : {item.description}
                  <br />
                  Assignee : {item.assignee}
                  <br />
                  <br />
                </li>
              ))}{" "}
            </ul>
          </div>
          <div style={defconRank}>
            DEFCON 5 Tasks
            <br />
            <ul style={taskStyle}>
              {esc5.map(item => (
                <li key={item.escalationVal}>
                  <br />
                  Task : {item.taskName}
                  <br />
                  Desc : {item.description}
                  <br />
                  Assignee : {item.assignee}
                  <br />
                  <br />
                </li>
              ))}{" "}
            </ul>
          </div>
        </div>
      );
    }
  }
}
