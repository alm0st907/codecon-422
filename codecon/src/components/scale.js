import React, { Component } from "react";
import Konva from "konva";
import { render } from "react-dom";
import { Stage, Layer, Rect, Line } from "react-konva";

//this is a class component

const xWidth = window.innerWidth / 2;
const yWidth = window.innerHeight;
export default class Scale extends Component {
  //This command will allow for the defcon scale import into other pages
  render() {
    return (
      <Stage width={xWidth} height={yWidth}>
        {/* stage is the canvas that you are drawing on */}
        <Layer offsetX={-xWidth / 4}>
          {/* there can be multiple layers with use in konva */}
          <Rect
            y={100}
            width={xWidth / 2}
            height={100}
            fill="blue"
            shadowBlur={10}
          />
          <Rect
            y={200}
            width={xWidth / 2}
            height={100}
            fill="green"
            shadowBlur={10}
          />
          <Rect
            y={300}
            width={xWidth / 2}
            height={100}
            fill="yellow"
            shadowBlur={10}
          />
          <Rect
            y={400}
            width={xWidth / 2}
            height={100}
            fill="red"
            shadowBlur={10}
          />
          {/*y is offset from top, x is offset from left side*/}
          <Rect
            y={500}
            width={xWidth / 2}
            height={100}
            fill="white"
            shadowBlur={10}
          />
        </Layer>
      </Stage>
    );
  }
}
