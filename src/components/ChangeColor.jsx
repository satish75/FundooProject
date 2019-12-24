import React from "react";
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Popper from '@material-ui/core/Popper';
import PopupState, { bindToggle, bindPopper } from 'material-ui-popup-state';
import Fade from '@material-ui/core/Fade';
import Paper from '@material-ui/core/Paper';
import { Component } from 'react';
import '../cssFiles/ChangeColor.css'
import RadioButtonUncheckedOutlinedIcon from '@material-ui/icons/RadioButtonUncheckedOutlined';
import { IconButton } from "@material-ui/core";
import AllIconList from './AllIconList'

export default class ChangeColor extends Component
{
    constructor(props)
    {
        super(props);
        this.state={
            bg: "white"
        }
    }

    changeCSS(clr) {
        console.log("Color ",clr);
        
        this.setState({
          bg: clr
        });
      };
    
      chagneBg = e => {
        let name = e.target.value;
        let oldObj = this.state.name;
        oldObj.name = name;
        this.setState({
          bg: e.target.value,
          name: oldObj
        });
      };
     
    render(){
        return(
            <div>
            {/* <PopupState variant="popper" popupId="demo-popup-popper">
            {popupState => ( */}
              <div className="allcolorButtonDiv">
               
           
                      <Paper id="paperContent">                      
                    <IconButton id="redColor" onClick={this.changeCSS.bind(this, "red")}/>
                    <IconButton id="blueColor"  onClick={this.changeCSS.bind(this, "blue")}/>
                    <IconButton id="blackColor"  onClick={this.changeCSS.bind(this, "black")}/>
                    <IconButton id="greenColor"  onClick={this.changeCSS.bind(this, "green")}/>
                    
                    <br/>
                    <IconButton id="pinkColor"  onClick={this.changeCSS.bind(this, "pink")}/>
                    <IconButton id="yellowColor"  onClick={this.changeCSS.bind(this, "yellow")}/>
                    <IconButton id="brownColor"  onClick={this.changeCSS.bind(this, "brown")}/>
                    <IconButton id="grayColor"  onClick={this.changeCSS.bind(this, "gray")}/>
                    <br/>
                    <IconButton id="purpleColor"  onClick={this.changeCSS.bind(this, "purple")}/>
                    <IconButton id="darkBlueColor"  onClick={this.changeCSS.bind(this, "darkblue")}/>
                    <IconButton id="oragneColor"  onClick={this.changeCSS.bind(this, "orange")}/>
                    <IconButton id="whiteColor"  onClick={this.changeCSS.bind(this, "white")}/>
                      </Paper>
                  


                {/* <div className="colorchangeeffect" style={{ background: `${this.state.bg}` }}>
                 <p>ghddddddddddddddddddddddddddddddddddddddddf</p>
              </div> */}

              </div>
            
        </div> 
        )
    }
}