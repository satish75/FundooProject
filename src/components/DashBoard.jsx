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
import Labeldata from './Label'
import EditLabel from './EditLabel'
import '../cssFiles/DashBoard.css';
import CheckIcon from '@material-ui/icons/Check';
import ClearOutlinedIcon from '@material-ui/icons/ClearOutlined';
import UserService from '../Services/UserService/UserService'

import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import { TextField } from '@material-ui/core';
import ClearIcon from '@material-ui/icons/Clear';

var labelObjService = new UserService;


class DashBoard extends Component {

  constructor(props) {
    super(props);

    this.state = {
      left: false,
      editlabel:false,
      createlabel:'',
      text:''

    }
    this.onchangeTextField=this.onchangeTextField.bind(this)
    this.AddLabelWithoutId=this.AddLabelWithoutId.bind(this)

  }
 example(){
  this.setState({left:false});
  console.log(this.state);
  
}

getAllTrashNotes = () =>
{
  this.props.history.push('/dashboard/trash')
}
getAllArchiveNotes = () =>
{
  this.props.history.push('/dashboard/archive')
}

getAllNotesBtn = () =>
{
  this.props.history.push('/dashboard/notes')
}

handleClickOpen = () => {
  this.setState({ editlabel: true })
};

handleClose = () => {
  this.setState({ editlabel: false })
};

AddLabelWithoutId() {
  var data = {               
    EditLabel: this.state.createlabel,                             
  }

  labelObjService.AddLabelWithoutNoteService(data).then(response=>{
      console.log(" response in ",response);
     
    })     
 }
onchangeTextField(e)
{
  this.setState({text: e.target.value});
  console.log("onchange method ",this.state.createlabel);
}
onchangeClearTextField(e)
{
  e.preventDefault();
    const text = this.state.text;
   
    this.createlabel.value = "";
}


  render() {

    const sideList =
      (

        <div className="DrawersIcon">
          <div className="ListButtons">


            <Button id="reminder-notes-btn" onClick={this.getAllNotesBtn}>

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
              <br />  <br /> 
              <Labeldata editLabelbool={ this.state.editlabel}/>
           
              <Button id="reminder-notes-btn"  onClick={this.handleClickOpen} >
                <AddAlertOutlinedIcon id="noteIcon"></AddAlertOutlinedIcon>
                Edit Label
         </Button>
         <div>

        <Dialog
          open={this.state.editlabel}
          onClose={this.handleClose}

        >
          <DialogTitle id="alert-dialog-title">edit Labels</DialogTitle>
          <DialogContent>
            <IconButton onClick={this.onchangeClearTextField}>
            <ClearIcon />
            </IconButton>
         
            <TextField placeholder="create label"  name="createlabel"
              onChange={this.onchangeTextField}
              value={this.state.text}
              />
           <Button onClick={this.AddLabelWithoutId}>   <CheckIcon /> </Button> 
            <Labeldata labelbool={this.state.editlabel}/>
           <br/>

          </DialogContent>
          <DialogActions>

            <Button onClick={this.handleClose} color="primary" autoFocus>
              Done
          </Button>
          </DialogActions>
        </Dialog>
     </div>


            </div>
            <Divider />
            <Button id="reminder-notes-btn"  onClick={this.getAllTrashNotes} >
              <DeleteOutlineOutlinedIcon id="noteIcon"></DeleteOutlineOutlinedIcon>
              Trash
      </Button>

            <br />
            <Button id="reminder-notes-btn"  onClick={this.getAllArchiveNotes} >
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