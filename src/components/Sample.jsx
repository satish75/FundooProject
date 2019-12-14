

import React, { Component } from "react";
import Button from "@material-ui/core/Button";
import PropTypes from "prop-types";

import { withStyles } from "@material-ui/core/styles";


  export default class Sample extends Component {
 
  constructor(props)
  {
    super(props);
    this.state = {
      bgButton: "primary",
    } 
  }
  
  handleClick = () => {
    this.setState({ bgButton: "secondary" }); 
  } 
  
  render() {
    const { bgButton } = this.state; 
    return(
     <div>
     <Button
       onClick = {this.handleClick} 
       variant = "contained" //checked Material UI documentation
       color={bgButton}
      /> 
      </div>
      )
}}

