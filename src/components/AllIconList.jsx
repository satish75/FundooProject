import React, { Component } from 'react';

import AccessAlarmsIcon from '@material-ui/icons/AccessAlarms';
import PersonAddIcon from '@material-ui/icons/PersonAdd';
import PaletteIcon from '@material-ui/icons/Palette';
import ImageIcon from '@material-ui/icons/Image';
import ArchiveIcon from '@material-ui/icons/Archive';
import UnarchiveIcon from '@material-ui/icons/Unarchive';
import MoreVertIcon from '@material-ui/icons/MoreVert';
import Menu from '@material-ui/core/Menu';
import IconButton from '@material-ui/core/IconButton';
import Badge from '@material-ui/core/Badge';

import Tooltip from '@material-ui/core/Tooltip';

import ListItemIcon from '@material-ui/core/ListItemIcon';

import MenuList from '@material-ui/core/MenuList';
import MenuItem from '@material-ui/core/MenuItem';


import Typography from '@material-ui/core/Typography';
import DraftsIcon from '@material-ui/icons/Drafts';
import SendIcon from '@material-ui/icons/Send';
import PriorityHighIcon from '@material-ui/icons/PriorityHigh';
import UserService from '../Services/UserService/UserService'
import '../cssFiles/AllIconList.css';
import { Button } from '@material-ui/core';
import Collaborator from './Collaborator'
import ChangeColor from './ChangeColor';

//proper
import Popper from '@material-ui/core/Popper';
import PopupState, { bindToggle, bindPopper } from 'material-ui-popup-state';
import Fade from '@material-ui/core/Fade';
import Paper from '@material-ui/core/Paper';
import DisplayNotes from './DisplayNotes';
import NotesOnLabel from './NotesOnLabel'

var deleteNoteaxios = new UserService;
export default class AllIconList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      show: 'false',
      collabarate: false,
      opencolor: false,
      colorCode: ''

    }
    this.handleClick = this.handleClick.bind(this)
    this.DeleteNote = this.DeleteNote.bind(this)
    this.TrashNote = this.TrashNote.bind(this)
    this.ArchiveNote = this.ArchiveNote.bind(this)
    // closePopup
  }

  state = {
    anchorEl: null,
  };

  handleClick = event => {
    this.setState({ anchorEl: event.currentTarget });
  };

  handleClose = () => {
    this.setState({ anchorEl: null });

  };

  DeleteNote() {
    var Id = this.props.noteId.id
    console.log("delete Id   ", Id)
    deleteNoteaxios.DeleteNotesService(Id).then(response => {
      console.log("this is response ", response)
    })
  }

  TrashNote() {
    var Id = this.props.noteId.id
    console.log("trash note value Id", Id)
    deleteNoteaxios.TrashNotesService(Id).then(response => {
      console.log("this is response ", response)
    })
  }
  AddLabels()
  { 
    return <div>
      <NotesOnLabel />
    </div>
  }

  ArchiveNote() {
    var Id = this.props.noteId.id
    console.log("Archive Id", Id)
    deleteNoteaxios.ArchiveNotesService(Id).then(response => {
      console.log("this is response ", response)
    })
  }
  openCollabarator = () => {
    this.setState({
      collabarate: !this.state.collabarate,
    });
  };
  colorFunction = () => {
    this.setState({
      colorCode: this.props.colorId
    })
  }
  render() {
    const colorbg = this.props.colorId
    console.log("this is AllIcon  cmpnt ", this.props.colorId);




    const { anchorEl } = this.state;

    return (

      <div className="allIconDiv">

        {/* {this.state.collabarate ?
          <Collaborator /> : ""}





        <Tooltip title="Reminder" enterDelay={250} leaveDelay={10}>
          <IconButton color="black">
            <Badge color="secondary">
              < AccessAlarmsIcon precision={1} />
            </Badge>
          </IconButton>
        </Tooltip>

        <Tooltip title="Image" enterDelay={250} leaveDelay={100}>
          <IconButton color="black">
            <Badge color="secondary">
              <ImageIcon />
            </Badge>
          </IconButton>
        </Tooltip>

        {/* <Tooltip title="Archive" enterDelay={250} leaveDelay={100}>
          <IconButton color="black" onClick={this.ArchiveNote}>
            <Badge color="secondary">
              <ArchiveIcon />
            </Badge>
          </IconButton>
        </Tooltip> */}

        <Tooltip title="More" enterDelay={250} leaveDelay={100}>
          <IconButton color="black" size="small" onClick={this.handleClick}>
            <MoreVertIcon fontSize="inherit"
              aria-owns={anchorEl ? 'simple-menu' : undefined}
              aria-haspopup="true"
            />
          </IconButton>
        </Tooltip>

        <div >
          <Menu className="paper-size-menu"
            id="simple-menu"
            anchorEl={anchorEl}
            open={Boolean(anchorEl)}
            onClose={this.handleClose}
          >
            <MenuItem onClick={this.TrashNote}>Delete Note </MenuItem>

      <MenuItem  ><NotesOnLabel /></MenuItem>
          </Menu>

        </div>

        <div>
        </div>
      </div>
    )
  }
} 