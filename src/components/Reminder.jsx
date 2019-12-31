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


var deleteNoteaxios = new UserService;
export default class Reminder extends Component {
  constructor(props) {
    super(props);
    this.state = {    
    } 
  }

  render() {
    return (

      <div>
        <Tooltip title="Reminder" enterDelay={250} leaveDelay={10}>
          <IconButton size="small"color="black">
            <Badge color="secondary">
              < AccessAlarmsIcon fontSize="inherit" precision={1} />
            </Badge>
          </IconButton>
        </Tooltip>
      </div>
    )
  }
} 