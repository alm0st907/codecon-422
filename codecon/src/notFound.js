import React from "react";
import styled from "styled-components";

//This should never change therefore it's constant

//using styled components (css-in-js)
const ErrorMessage = styled.h1`
  font-size: 4.5em;
  font-weight: bold;
  text-align: center;
  color: white;
`;

const NotFound = () => {
  return <ErrorMessage>DEFCON -1: Page Not Found!</ErrorMessage>;
};

export default NotFound;
