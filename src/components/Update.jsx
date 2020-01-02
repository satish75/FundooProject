import React from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import { Component } from 'react';
import InputBase from '@material-ui/core/InputBase';
import ChangeColor from './ChangeColor'
import Collaborator from './Collaborator'
import Labeldata from './Label'
import ArchiveIconComponent from './ArchiveIconComponent'
import Reminder from './Reminder'
import '../cssFiles/Update.css'
export default class Update extends Component {
 constructor(props){
   super(props)
   this.state={
    setOpen:true,
    open:true,
    title:this.props.title,
    description:this.props.desc
   }
 }

   handleClickOpen = () => {
   this.setState({
    
   })
  };

   handleClose = () => {
    this.setState({
      setOpen:false,
      open:false
    })
  };
render(){
console.log("title of notes ",this.props.title);
console.log("title of notes ",this.props.desc);

  return (
    <div>
      {/* <Button variant="outlined" color="primary" onClick={this.handleClickOpen}>
        Open alert dialog
      </Button> */}
      <Dialog
        open={this.state.open}
        onClose={this.handleClose}
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
        
        <DialogContent>
        
        <InputBase
        fullWidth
        multiline="true"
        className=""
       placeholder="Title"
        inputProps={{ 'aria-label': 'naked' }}
      />
      <br/>
      <InputBase
        className="" 
        fullWidth
        multiline="true"
        placeholder="Description"
        inputProps={{ 'aria-label': 'naked' }}
      />
      <div id="IconComponent">
      <Collaborator />
  <ChangeColor />
  <Reminder />
  <Button onClick={this.handleClose} color="primary" autoFocus>
            CLOSE
          </Button>
  {/* <ArchiveIconComponent /> */}
      </div>
 
        </DialogContent>

        <DialogActions>       
          
        </DialogActions>
      </Dialog>
    </div>
  );
}
}