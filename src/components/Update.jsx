import React from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import Paper from '@material-ui/core/Paper';
import Draggable from 'react-draggable';
import { ThemeProvider, createMuiTheme, TextareaAutosize } from '@material-ui/core'
import AllIconList from './AllIconList'
import UnarchiveIcon from '@material-ui/icons/Unarchive';
import '../cssFiles/Update.css'
function PaperComponent(props) {
  return (
    <Draggable cancel={'[class*="MuiDialogContent-root"]'}>
      <Paper {...props} />
    </Draggable>
  );
}

export default function Update() {
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <Button variant="outlined" color="primary" onClick={handleClickOpen}>
        Open form dialog
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
        PaperComponent={PaperComponent}
        aria-labelledby="draggable-dialog-title"
      >
               <DialogContent>
<div>
      <TextareaAutosize id="textfieldTitle"
         multiline
         InputProps={{ disableUnderline: true }}
         className="title-text-area"  name="notesTitle" placeholder="Title"
         contentEditable="true"
       />
            <UnarchiveIcon />
                    
                       <TextareaAutosize id="textfielddescription"
                        className="note-text-area"
                          multiline
                          InputProps={{ disableUnderline: true }}
                          name="notesDescription"  placeholder="Take A Note"
                          contentEditable="true"
                        />
                   
                   </div>
                       <div className="allIconAndDescDiv">
                         <AllIconList />  
                          <Button className="close-btn-note" >CLOSE</Button>
                        

                      </div>
                      
        </DialogContent>
       
      </Dialog>
    </div>
  );
}
