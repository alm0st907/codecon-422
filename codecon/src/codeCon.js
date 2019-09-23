import React from 'react';
import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';
import logo from './logo.svg';

function codeCon() {
  return (
      <div className="codeCon">
          <h1 style={ { color: 'white' } }>Please login to defcon: </h1>
          {' '}
          {/* more inline css */}
          <Button tag={ Link } to="/scale" id="login" color="success" size="medium">
        Login
          </Button>
      </div>
  );
}

export default codeCon;
