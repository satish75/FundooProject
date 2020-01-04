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
import DisplayNotes from './DisplayNotes'
import ArchiveIconComponent from './ArchiveIconComponent'
import Reminder from './Reminder'
import '../cssFiles/Update.css'
import UserService from '../Services/UserService/UserService'

var updatenote =new UserService();
export default class Update extends Component {
 constructor(props){
   super(props)
   this.state={
    setOpen:true,
    open:true,
    title:this.props.title,
    description:this.props.desc,
    noteId:this.props.noteId,
    userId:this.props.userId
   }
  //  this.updatenoteData =this.updatenoteData.bind(this)
 }


  onchangeInput = (e) =>{
    this.setState({[e.target.name]: e.target.value});
  }
  //  handleClose = () => {
  //   this.setState({
  //     setOpen:false,
  //     open:false
  //   })
  //   this.updatenoteData();
  // };

  updatenoteData=()=>
  {
    this.setState({
      setOpen:!this.state.setOpen,
      open: !this.state.open
    })
    var data = {
                 
      title: this.state.title,                             
      description : this.state.description,
      userId:this.state.userId,
      noteId:this.state.noteId
    }
    
    updatenote.UpdateNotesService(data).then(response=>{
        console.log(" response in update",response);
         this.props.save2();
        /// console.log("props in update",this.props.save2())
      })
     
  }
render(){
console.log("title of notes ",this.state.title);
console.log("description of notes ",this.state.description);

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
        value={this.state.title}
        onChange={this.onchangeInput}
         name="title"
       placeholder="Title"
        inputProps={{ 'aria-label': 'naked' }}
      />
      <br/>
      <InputBase
        className="" 
        fullWidth
        name="description"
        multiline="true"
        value={this.state.description}
        onChange={this.onchangeInput}
        placeholder="Description"
        inputProps={{ 'aria-label': 'naked' }}
      />
      <div id="IconComponent">
      <Collaborator />
  <ChangeColor />
  <Reminder />
  <Button onClick={this.updatenoteData} color="primary" autoFocus>
            CLOSE
          </Button>
   

      </div>
 
        </DialogContent>

        <DialogActions>       
          { this.props.save2()}
        </DialogActions>
      </Dialog>
    </div>
  );
}
}