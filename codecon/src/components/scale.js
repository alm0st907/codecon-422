import React, { Component } from "react";
import Konva from "konva";
import { render } from "react-dom";
import { Stage, Layer, Rect, Line } from "react-konva";

//this is a class component
export default class Scale extends Component { 
  //This command will allow for the defcon scale import into other pages
  render() { 
    return (
      <Stage width={window.innerWidth/2} height={window.innerHeight}>
        {/* stage is the canvas that you are drawing on */}
        <Layer> 
          {/* there can be multiple layers with use in konva */}
          <Rect
            x={20}
            y={100}
            width={100}
            height={100}
            fill="blue"
            shadowBlur={10}
          />
          <Rect
            x={20}
            y={200}
            width={100}
            height={100}
            fill="green"
            shadowBlur={10}
          />
          <Rect
            x={20}
            y={300}
            width={100}
            height={100}
            fill="yellow"
            shadowBlur={10}
          />
          <Rect
            x={20}
            y={400}
            width={100}
            height={100}
            fill="red"
            shadowBlur={10}
          />
          {/*y is offset from top, x is offset from left side*/}
          <Rect
            x={20}
            y={500}
            width={100}
            height={100}
            fill="white"
            shadowBlur={10}
          />
        </Layer>
      </Stage>
    );
  }
}
