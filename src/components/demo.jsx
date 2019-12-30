import React, { Component } from 'react';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import '../cssFiles/demo.css'
import CheckIcon from '@material-ui/icons/Check';
import ClearOutlinedIcon from '@material-ui/icons/ClearOutlined';
import { TextField } from '@material-ui/core';
import Labeldata from './Label'

export default class Demo extends Component {
  constructor(props) {
    super(props);
    this.state = {
      open: false,

    }
  }

  handleClickOpen = () => {
    this.setState({ open: true })
  };

  handleClose = () => {
    this.setState({ open: false })
  };

  render() {
console.log("label data render ",this.props.labelvalue);

    return (
      <div>
        <Button variant="outlined" color="primary" onClick={this.handleClickOpen}>
          Open alert dialog
      </Button>
        <Dialog
          open={this.state.open}
          onClose={this.handleClose}

        >
          <DialogTitle id="alert-dialog-title">edit Labels</DialogTitle>
          <DialogContent>
            <ClearOutlinedIcon />
            <TextField placeholder="create label" />
            <CheckIcon />
            <Labeldata />
           <br/>

          </DialogContent>
          <DialogActions>

            <Button onClick={this.handleClose} color="primary" autoFocus>
              Done
          </Button>
          </DialogActions>
        </Dialog>
      </div>
    );
  }
}