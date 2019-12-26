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
import DisplayNotes from "./DisplayNotes";
import PaletteIcon from '@material-ui/icons/Palette';
import UserService from '../Services/UserService/UserService'

import Badge from '@material-ui/core/Badge';
import Tooltip from '@material-ui/core/Tooltip';


var getnotes = new UserService;

export default class ChangeColor extends Component
{
    constructor(props)
    {
        super(props);
        this.state={
            bg: "",
            showColorMenu:false
        }
        this.colorChange = this.colorChange.bind(this)
    }

    

    DisplayColors = ()=>{
      this.setState({
        showColorMenu: !this.state.showColorMenu
      })
    }
    
    changeCSS(clr) {
        console.log("Color ",clr);
        
        this.setState({
          bg: clr
        });
      };
    
     
    async  colorChange(clr) {
        console.log("This is funtion")

      await  this.setState({
          bg: clr
        });
          var data = {
                 
            color: this.state.bg,                             
            Id : this.props.idItem,       
          }
         
            getnotes.ColorService(data).then(response=>{
              console.log(" response in ",response);
             this.props.save()
              
            })            
    }
    render(){
      console.log("color value ",this.state.showColorMenu);
      
        return(
            <div>
           <PopupState variant="popper" popupId="demo-popup-popper">    
      {popupState => (
        <div>
            <Tooltip title="Color" enterDelay={250} leaveDelay={100}>
             <IconButton color="black" onClick={this.DisplayColors} >
             <Badge color="secondary">
              <PaletteIcon />
            </Badge>
           </IconButton>
           </Tooltip>

          <Popper {...bindPopper(popupState)} transition>
            {({ TransitionProps }) => (
              <Fade {...TransitionProps} timeout={350}>
             
              </Fade>
            )}
          </Popper>
        </div>
      )}
    </PopupState> 
   
          {this.state.showColorMenu ===true ?
              <div className="allcolorButtonDiv">
                      <Paper id="paperContent">                      
                    <IconButton id="redColor" onClick={this.colorChange.bind(this, "lightBlue")}/>
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
                  


                {/* { <div className="colorchangeeffect" style={{ background: `${this.state.bg}` }}>
                 <p>ghddddddddddddddddddddddddddddddddddddddddf</p>
              </div> } */}


              </div>
              :null}
                         
        </div> 
        )
    }
}