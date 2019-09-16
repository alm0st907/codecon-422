import React from "react";
import { Route, Switch } from "react-router-dom";
import NotFound from "./notFound";
// import Hello from "./codeCon";
import DefconScale from "./components/scale";
import TestNav from "./components/admin-navbar";
import Login from "./login";
import UserNav from "./components/user-navbar"
import MainView from "./components/main"
//These routes will also be constant
const Routes = () => {
  return (
    <div>
      <Switch>
        {" "}
        {/*With a switch, it will only render ONE component*/}
        {/* Have it setup so login is first page displayed */}
        <Route exact path="/" component={Login} />{" "}
        {/*exact is required as it'll only render if the path is exactly what is defined, otherwise it defaults to the notfound component (aka 404)*/}
        <Route path="/scale" component={DefconScale} />
        <Route path="/navbar" component={TestNav} />
        <Route path="/usrnav" component={UserNav} />
        <Route path="/main" component={MainView} />
        <Route component={NotFound} />{" "}
        {/*this will return the not found statement if none of the above paths are found-ALWAYS AT BOTTOM*/}
      </Switch>
    </div>
  );
};

export default Routes;
