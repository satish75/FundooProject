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
import { InputBase } from '@material-ui/core';

import MoreVertIcon from '@material-ui/icons/MoreVert';
import MenuList from '@material-ui/core/MenuList';
import MenuItem from '@material-ui/core/MenuItem';
import CheckIcon from '@material-ui/icons/Check';

var getnotes = new UserService;

export default class NotesOnLabel extends Component {
  constructor(props) {
    super(props);
    this.state = {
      checkedA: false,
      checkedItems: new Map(),
      AllLabel: [],
      moreIcon: true,
      checked: false,
      name: '',
      getAllLabel: []
    }
    this.getLabelsNotes = this.getLabelsNotes.bind(this)
    this.handleChange = this.handleChange.bind(this);
    this.openFirstMenu = this.openFirstMenu.bind(this);

  }

  handleChange(e) {
    const item = e.target.name;
    const isChecked = e.target.checked;
    this.setState(({ checkedItems: this.state.checkedItems.set(item, isChecked) }));

  }
  handleChange = name => event => {
    this.setState({ [name]: event.target.value });
  };
  componentWillMount() {
    this.getLabelsNotes()
  }

  openFirstMenu() {
    this.setState({
      moreIcon: !this.state.moreIcon
    })
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

  DisplayCPopper = () => {
    this.setState({
      showPopper: !this.state.showPopper
    })
  }

  render() {

    console.log("render in Checked value  ", this.state.checkedItems);

    var printNoteList = this.state.getAllLabel.map((item, index) => {
      const datalabel = item.label
      console.log('data label value Id ');

      return (
        <div>
          <FormControlLabel
            control={
              <Checkbox
               checked={this.state.checkedItems.get(item.label)} 
                onChange={this.handleChange}
                value="primary"
                inputProps={{ 'aria-label': 'primary checkbox' }}
              />
            }
            label={item.label}
          />
        </div>
      )
    })
    return (
      <div>
        {this.state.moreIcon === true ?
          <Tooltip title="Color" enterDelay={250} leaveDelay={100}>
            <IconButton size="small" color="black" onClick={this.openFirstMenu}>
              <Badge color="secondary">
                <MoreVertIcon fontSize="inherit" />
              </Badge>
            </IconButton>
          </Tooltip>
          :
          <PopupState variant="popper" popupId="demo-popup-popper">
            {popupState => (
              <div>
                <MenuItem {...bindToggle(popupState)} >Add Label </MenuItem>
                <MenuItem {...bindToggle(popupState)} >Note Delete </MenuItem>
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

                <Popper {...bindPopper(popupState)} transition>
                  {({ TransitionProps }) => (
                    <Fade {...TransitionProps} timeout={350}>
                      <Paper id="paper-component">
                        <div>
                          <label>Label Note</label>
                          <br />
                          <InputBase
                            id="standard-name"
                            value={this.state.name}
                            placeholder="create new label"
                            onChange={this.handleChange('name')}
                            margin="normal"
                          />
                          <Button onClick={this.openFirstMenu}>
                            <CheckIcon />
                          </Button>
                        </div>
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
        }
      </div>
    )
  }
}