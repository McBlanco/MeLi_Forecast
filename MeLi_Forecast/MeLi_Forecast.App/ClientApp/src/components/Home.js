import React, { Component } from 'react';
import { ScatterChart, Scatter, XAxis, YAxis, CartesianGrid, Tooltip } from 'recharts';
import { SpinButton, Icon } from 'office-ui-fabric-react';

export class Home extends Component {
  static displayName = Home.name;

  _initialState = {
    id: 0,
    day: 0,
    ferengiPosition: '{ "x": 1000, "y": 0}',
    betasoidePosition: '{ "x": 2000, "y": 0}',
    vulcanoPosition: '{ "x": 500, "y": 0}',
    areAlignedWithTheSun: false,
    areAlignedWithoutTheSun: false,
    betasoideAngle: 0,
    ferengiAngle: 0,
    vulcanoAngle: 0,
    isSunInside: false,
    weather: "tempered",
  };

  constructor(props) {
    super(props);

    this.state = this._initialState;

    fetch('api/forecast?day=0')
      .then(response => response.json())
      .then(data => {
        this.setState(data)
      });
  }

  render() {
    console.log(this.state);
    return (
      <div>
        <SpinButton value={this.state.day} min={0} max={3649} step={1} label={"Day"} onIncrement={(value) => this._onChangeDay(true, value)} onDecrement={(value) => this._onChangeDay(false, value)} />
        <div style={{flexWrap: "wrap", display: "flex"}}>
          <ScatterChart width={400} height={400} margin={{ top: 20, right: 20, bottom: 20, left: 20 }}>
            <CartesianGrid />
            <XAxis type="number" dataKey="x" width={2000} />
            <YAxis type="number" dataKey="y" height={2000} />
            <Tooltip cursor={{ strokeDasharray: '3 3' }} />
            <Scatter name="Ferengi" data={[{ x: 2000, y: 2000 }, { x: -2000, y: -2000 }]} fill="transparent" />
            <Scatter name="Sun" data={[{ x: 0, y: 0 }]} fill="orange" shape="star" />
            <Scatter name="Ferengi_Betasoide" data={[{ x: JSON.parse(this.state.ferengiPosition).x, y: JSON.parse(this.state.ferengiPosition).y }, { x: JSON.parse(this.state.betasoidePosition).x, y: JSON.parse(this.state.betasoidePosition).y }]} line fill="gray" />
            <Scatter name="Ferengi_Vulcano" data={[{ x: JSON.parse(this.state.ferengiPosition).x, y: JSON.parse(this.state.ferengiPosition).y }, { x: JSON.parse(this.state.vulcanoPosition).x, y: JSON.parse(this.state.vulcanoPosition).y }]} line fill="gray" />
            <Scatter name="Betasoide_Vulcano" data={[{ x: JSON.parse(this.state.betasoidePosition).x, y: JSON.parse(this.state.betasoidePosition).y }, { x: JSON.parse(this.state.vulcanoPosition).x, y: JSON.parse(this.state.vulcanoPosition).y }]} line fill="gray" />
            <Scatter name="Ferengi" data={[{ x: JSON.parse(this.state.ferengiPosition).x, y: JSON.parse(this.state.ferengiPosition).y }]} fill="red" />
            <Scatter name="Betasoide" data={[{ x: JSON.parse(this.state.betasoidePosition).x, y: JSON.parse(this.state.betasoidePosition).y }]} fill="blue" />
            <Scatter name="Vulcano" data={[{ x: JSON.parse(this.state.vulcanoPosition).x, y: JSON.parse(this.state.vulcanoPosition).y }]} fill="green" />
          </ScatterChart>
          <div>
            <div style={{ color: "red", padding: "1rem" }}>
              <h6>Ferengi</h6>
              <div>{`Position: ${this.state.ferengiPosition}`}</div>
              <div>{`Angle: ${this.state.ferengiAngle}º`}</div>
            </div>
            <div style={{ color: "blue", padding: "1rem" }}>
              <h6>Betasoide</h6>
              <div>{`Position: ${this.state.betasoidePosition}`}</div>
              <div>{`Angle: ${this.state.betasoideAngle}º`}</div>
            </div>
            <div style={{ color: "green", padding: "1rem" }}>
              <h6>Vulcano</h6>
              <div>{`Position: ${this.state.vulcanoPosition}`}</div>
              <div>{`Angle: ${this.state.vulcanoAngle}º`}</div>
            </div>
          </div>
          <div>
            <div style={{color: this.state.areAlignedWithTheSun ? "green" : "black"}}>{`Are aligned with the sun: ${this.state.areAlignedWithTheSun}`}</div>
            <div style={{color: this.state.areAlignedWithoutTheSun ? "green" : "black"}}>{`Are aligned without the sun: ${this.state.areAlignedWithoutTheSun}`}</div>
            <div style={{color: this.state.isSunInside ? "green" : "black"}}>{`Is the sun inside: ${this.state.isSunInside}`}</div>
            <div style={{fontSize: "1.1rem", fontWeight: 600}}>{`Weather: ${this.state.weather}`}</div>
          </div>
        </div>
      </div>
    );
  }

  _onChangeDay = (isIncrement, input) => {

    
    var day = isIncrement ? this.state.day + 1 : this.state.day - 1;

    /* Take the value put by user, instead of increment/decrement */
    var value = isIncrement ? parseInt(input) + 1 : parseInt(input) - 1;
    if (value !== day)
      day = value;

    this.setState({
      ...this.state,
      day: day,
    })

    fetch(`api/forecast?day=${day}`)
      .then(response => response.json())
      .then(data => {
        console.log(data)
        this.setState(data)
      });
  }
}
