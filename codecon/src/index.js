import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import * as serviceWorker from "./serviceWorker";
import { Router } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.css"; //gives us access to bootstrap framework (necessary for reactstrap usage)
import { createBrowserHistory } from "history"; //error fix: https://github.com/ReactTraining/history/issues/680

//https://github.com/ReactTraining/react-router/blob/master/packages/react-router/docs/api/Router.md refer to this
import CodeConStart from "./codeCon";
import Routes from "./routes";

const history = createBrowserHistory(); //gives us access to the browser history

ReactDOM.render(
  <Router history={history}>
    <Routes />
  </Router>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
