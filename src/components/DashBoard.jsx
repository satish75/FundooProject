import React, { Component } from 'react'
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';


import MenuIcon from '@material-ui/icons/Menu';

import Drawer from '@material-ui/core/Drawer';
import SearchIcon from '@material-ui/icons/Search';
import RefreshIcon from '@material-ui/icons/Refresh'
import Settings from '@material-ui/icons/Settings'
import DeleteOutlineOutlinedIcon from '@material-ui/icons/DeleteOutlineOutlined';
import { Button, Label, Divider } from '@material-ui/core';
import List from '@material-ui/core/List';
import NoteOutlinedIcon from '@material-ui/icons/NoteOutlined';
import AddAlertOutlinedIcon from '@material-ui/icons/AddAlertOutlined';
import ArchiveOutlinedIcon from '@material-ui/icons/ArchiveOutlined';
import IconButton from '@material-ui/core/IconButton';
import InputBase from '@material-ui/core/InputBase';
import Badge from '@material-ui/core/Badge';
import MenuItem from '@material-ui/core/MenuItem';
import Menu from '@material-ui/core/Menu';

import '../cssFiles/DashBoard.css';

class DashBoard extends Component {

  constructor(props) {
    super(props);

    this.state = {
      left: false,

    }
  }
 example(){
  this.setState({left:false});
  console.log(this.state);
  
}


  //  toggleDrawer = (side, open) => event => {
  //     if (event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')) {
  //       return;
  //     }

  //     setState({ ...state, [side]: open });
  //   };

  render() {

    const sideList =
      (

        <div className="DrawersIcon">
          <div className="ListButtons">



            <Button id="reminder-notes-btn" >

              <NoteOutlinedIcon id="noteIcon"></NoteOutlinedIcon>
              Note
     </Button>

            <Button id="reminder-notes-btn" onClick={this.colorBgChange}
            >
              <AddAlertOutlinedIcon id="noteIcon"></AddAlertOutlinedIcon>
              Reminders
       </Button>

            <Divider />
            <div>
              <span id="span-label">Labels   </span>
              <br />  <br />  <br />
              <Button id="reminder-notes-btn"   >
                <AddAlertOutlinedIcon id="noteIcon"></AddAlertOutlinedIcon>
                Edit Label
         </Button>

            </div>
            <Divider />
            <Button id="reminder-notes-btn"   >
              <DeleteOutlineOutlinedIcon id="noteIcon"></DeleteOutlineOutlinedIcon>
              Trash
      </Button>


            <br />
            <Button id="reminder-notes-btn"   >
              <ArchiveOutlinedIcon id="noteIcon"></ArchiveOutlinedIcon>
              Archive
      </Button>
          </div>
        </div>
      );


    return (
      <div className="header-div">
        <AppBar position="static">
          <Toolbar>
            <IconButton edge="start" color="inherit" aria-label="menu">
              <MenuIcon
                onClick={e => this.setState({ left: !this.state.left })}
              />
            </IconButton>
            <Typography variant="h6">
              Fundoo
                        </Typography>

           <div className="Search-icon-div">
                        <SearchIcon  id="search-icon"/>  
            <InputBase className="Search"
              placeholder="Search…"
               />
               </div>

        <div >
            <IconButton color="black" className="left-icon-setting">
              <Badge color="secondary">
                <RefreshIcon />
              </Badge>
            </IconButton>

            <IconButton color="black" className="left-icon-setting">
              <Badge color="secondary">
                <Settings />
              </Badge>
            </IconButton>

            </div>
          </Toolbar>
        </AppBar>
        {/* the drawwer code */}

        <div>
          <Divider />


          <Drawer

            variant="persistent"
            open={this.state.left}
            onClose={e => this.setState({ left: false })}
          >
            <div style={{ width: "250px" }}>
              {sideList}
            </div>

          </Drawer>

        </div>

      </div>
    );
  }
}

export default DashBoard;