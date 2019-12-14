import React, { Component } from 'react';
import clsx from 'clsx';
import { makeStyles, useTheme } from '@material-ui/core/styles';
import Drawer from '@material-ui/core/Drawer';
import CssBaseline from '@material-ui/core/CssBaseline';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import InputBase from '@material-ui/core/InputBase';
import List from '@material-ui/core/List';
import Typography from '@material-ui/core/Typography';
import Divider from '@material-ui/core/Divider';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import NoteOutlinedIcon from '@material-ui/icons/NoteOutlined';
import AddAlertOutlinedIcon from '@material-ui/icons/AddAlertOutlined';
import DeleteOutlineOutlinedIcon from '@material-ui/icons/DeleteOutlineOutlined';
import ArchiveOutlinedIcon from '@material-ui/icons/ArchiveOutlined';
import NotificationsIcon from '@material-ui/icons/Notifications';
import '../cssFiles/demo.css'
import RefreshIcon from '@material-ui/icons/Refresh'
import Settings from '@material-ui/icons/Settings'
import Badge from '@material-ui/core/Badge';
import SearchIcon from '@material-ui/icons/Search';
import MailIcon from '@material-ui/icons/Mail';
import { ThemeProvider ,createMuiTheme} from '@material-ui/core'
import Notes from './Notes'
const drawerWidth = 240;


const theme = createMuiTheme({
   
    overrides:{
        MuiDrawer:{
            paper:{
                top:"63px"
            }
        },


    }
  });

export default class Demo extends Component {
constructor()
{
    super();
    this.state={
     left:false
    }
}

handleDrawerOpen = () => {
    this.setState({
      left: !this.state.left,
    });
  };
  
render()
{

  return (
    <div className="main-div-dash">
    <div >
      <CssBaseline />
      <AppBar
        position="fixed"
      
      >
        <Toolbar>
          <IconButton
            color="inherit"
            aria-label="open drawer"
            onClick={this.handleDrawerOpen}
            edge="start">
            <MenuIcon />
          </IconButton>

           <Typography id="new" className="title" variant="h6" noWrap color="inherit"> </Typography>
                 <span className="TextSpan" aria-level="1" role="heading">Fundoo </span> 

                 <div className="mainDiv">
                    <div className="searchIcon">
                        <SearchIcon />
                        <InputBase placeholder="Search…" className="Search" inputProps={{ 'aria-label': 'search' }}/>
                    </div>
                </div>
           
            <div classname="RefreshIcon">  
                <IconButton color="black">
                <Badge  color="secondary">
                <RefreshIcon />
                </Badge>
                </IconButton>
            </div>

            <div classname="SettingIcon">  
                 <IconButton color="black">
                  <Badge  color="secondary">
                  <Settings />
                 </Badge>
                 </IconButton>
            </div>     
        </Toolbar>
      </AppBar>
      </div>

    <div className="second-div"> 
<div className="noteCreateDiv">
 <Notes/>
</div>

      <div className="note-middle-div">
   <h1>gsagddfjgggggggggggggggggggg</h1>
   
  </div>

  </div>


      <div>
      <ThemeProvider theme={theme}>
      <Drawer
      
        variant="persistent"
        anchor="left"
        open={this.state.left}
      >
       
        <Divider />
        <div className="note-reminder-div">
      <IconButton id="note-icon-btn-left-side">
          <NoteOutlinedIcon id="icon-img-btn" />
          Note
      </IconButton>
      <br/>
      <IconButton id="reminder-icon-btn-left-side">
          <AddAlertOutlinedIcon id="icon-img-btn" />
          Reminder
      </IconButton>
      </div>
      <Divider />
      <div className="label-div-drawer">
        <span>Labels</span><br/><br/>
        <IconButton id="edit-icon-label">
          <AddAlertOutlinedIcon id="icon-edirlabel-btn" />
          Edit Label
      </IconButton>
      </div>
      <Divider />
      <div>
      <IconButton id="note-icon-btn-left-side">
          <ArchiveOutlinedIcon id="icon-img-btn" />
          Archive
      </IconButton>
      <br/>
      <IconButton id="reminder-icon-btn-left-side">
          <DeleteOutlineOutlinedIcon id="icon-img-btn" />
          Trash
      </IconButton>
        </div>
      </Drawer>
      </ThemeProvider>
    </div>
   
    </div>
    
  );
}}