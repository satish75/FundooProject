import React from "react";
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Popper from '@material-ui/core/Popper';
import PopupState, { bindToggle, bindPopper } from 'material-ui-popup-state';
import Fade from '@material-ui/core/Fade';
import Paper from '@material-ui/core/Paper';
import { Component } from 'react';


import FormGroup from '@material-ui/core/FormGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import CheckBoxOutlineBlankIcon from '@material-ui/icons/CheckBoxOutlineBlank';
import CheckBoxIcon from '@material-ui/icons/CheckBox';
import Favorite from '@material-ui/icons/Favorite';
import FavoriteBorder from '@material-ui/icons/FavoriteBorder';

import { IconButton } from "@material-ui/core";
import AllIconList from './AllIconList'
import DisplayNotes from "./DisplayNotes";
import PaletteIcon from '@material-ui/icons/Palette';
import UserService from '../Services/UserService/UserService'

import Badge from '@material-ui/core/Badge';
import Tooltip from '@material-ui/core/Tooltip';


var getnotes = new UserService;

export default class NotesOnLabel extends Component
{
    constructor(props)
    {
        super(props);
        this.state={
            checkedA: false,
            checkedItems: new Map(),
            AllLabel: [],
            getAllLabel: []
        }
        this.getLabelsNotes=this.getLabelsNotes.bind(this)
        this.handleChange = this.handleChange.bind(this);
      
    }

    handleChange(e) {
        const item = e.target.name;
        const isChecked = e.target.checked;
        this.setState(prevState => ({ checkedItems: prevState.checkedItems.set(item, isChecked) }));
      }
    
    componentWillMount()
    {
        this.getLabelsNotes() 
    }

    getLabelsNotes() {
        console.log("This is funtion")

        getnotes.GetLabelService().then(response => {
            console.log(response);
            let array = [];
            console.log(" log ", response);

            response.data.data.map((data) => {
                array.push(data);
            });
            this.setState({
                getAllLabel: array
            })

        });

    }

    DisplayCPopper = ()=>{
      this.setState({
        showPopper: !this.state.showPopper
      })
    }

    render(){
    
        var printNoteList = this.state.getAllLabel.map((item, index) => {
            const datalabel = item.label
            console.log('data label value Id ');
            console.log("render in new label ",item.label);
            return (
                <div>
          
          <FormControlLabel
           control={
          <Checkbox
            checked={this.state.checkedItems.get(item.label)} 
            onChange={this.handleChange} 
            value={item.label}
            color="primary"
          />
        }
        label={item.label}
      />  
              </div>        
              
            )
        })
        return(
            <div>

     <PopupState variant="popper" popupId="demo-popup-popper">
      {popupState => (
        <div>
        
          <Tooltip title="Color" enterDelay={250} leaveDelay={100}>
             <IconButton  size="small" color="black" {...bindToggle(popupState)} >
             <Badge color="secondary">
             <Button> Add Label</Button>
            </Badge>
           </IconButton>
           </Tooltip>

          <Popper {...bindPopper(popupState)} transition>
            {({ TransitionProps }) => (
              <Fade {...TransitionProps} timeout={350}>
                <Paper id="paper-component">
                <div >
               {printNoteList}               
              </div>
                </Paper>
              </Fade>
            )}
          </Popper>
        </div>
      )}
    </PopupState>
                   
        </div> 
        )
    }
}