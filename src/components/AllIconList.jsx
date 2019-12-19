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
import Paper from '@material-ui/core/Paper';

import Typography from '@material-ui/core/Typography';
import DraftsIcon from '@material-ui/icons/Drafts';
import SendIcon from '@material-ui/icons/Send';
import PriorityHighIcon from '@material-ui/icons/PriorityHigh';

import '../cssFiles/AllIconList.css';


export default class AllIconList extends Component
{
    constructor(props)
    {
        super(props);
        this.state={
            show:'false',
        }
        this.handleClick=this.handleClick.bind(this)
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

    

    render(){
        const { anchorEl } = this.state;
       
        return(

            <div className="icon-div-flex">
                            

                            <Tooltip title="Reminder" enterDelay={250} leaveDelay={10}>
                             <IconButton color="black">
                             <Badge  color="secondary">
                             < AccessAlarmsIcon precision={1} className="bottom-icon-list"/>
                             </Badge>
                             </IconButton>
                             </Tooltip>

                             <Tooltip title="Collaborate" enterDelay={250} leaveDelay={100}>
                             <IconButton color="black">
                             <Badge  color="secondary">
                             <PersonAddIcon  className="bottom-icon-list"/>
                             </Badge>
                             </IconButton>
                             </Tooltip>

                              <Tooltip title="Color" enterDelay={250} leaveDelay={100}>
                              <IconButton color="black">
                               <Badge  color="secondary">
                               <PaletteIcon  className="bottom-icon-list"/>
                               </Badge>
                               </IconButton>
                               </Tooltip>

               
                               <Tooltip title="Image" enterDelay={250} leaveDelay={100}>
                               <IconButton color="black">
                               <Badge  color="secondary">
                               <ImageIcon  className="bottom-icon-list"/>
                               </Badge>
                               </IconButton>
                               </Tooltip>

                               <Tooltip title="Archive" enterDelay={250} leaveDelay={100}>
                               <IconButton color="black">
                                <Badge  color="secondary">
                               <ArchiveIcon  className="bottom-icon-list"/>   
                               </Badge>
                               </IconButton>
                               </Tooltip>

     
                                 <Tooltip title="More" enterDelay={250} leaveDelay={100}>
                                 <IconButton color="black" onClick={this.handleClick}>
                                 <Badge  color="secondary">
                                 <MoreVertIcon  className="bottom-icon-list"
                                  aria-owns={anchorEl ? 'simple-menu' : undefined}
                            
                                  aria-haspopup="true"
                                  onClick={this.handleClick}
                                 />
                                 </Badge>
                                 </IconButton>
           
           
                                 </Tooltip> 
       <div >
        <Menu className="paper-size-menu"
          id="simple-menu"
          anchorEl={anchorEl}
          open={Boolean(anchorEl)}
          onClose={this.handleClose}
        >
          <MenuItem onClick={this.handleClose}>Delete Note </MenuItem>
          <MenuItem onClick={this.handleClose}>Add Label</MenuItem>
         
        </Menu>
                               
                </div>                 
            </div>
        )
    }
} 