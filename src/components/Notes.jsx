import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import Button from '@material-ui/core/Button';
import Settings from '@material-ui/icons/Settings';
import AddAlertTwoToneIcon from '@material-ui/icons/AddAlertTwoTone';
import AccessAlarmsIcon from '@material-ui/icons/AccessAlarms';
import PersonAddIcon from '@material-ui/icons/PersonAdd';
import PaletteIcon from '@material-ui/icons/Palette';
import ImageIcon from '@material-ui/icons/Image';
import ArchiveIcon from '@material-ui/icons/Archive';
import UnarchiveIcon from '@material-ui/icons/Unarchive';
import MoreVertIcon from '@material-ui/icons/MoreVert';
import UndoIcon from '@material-ui/icons/Undo';
import RedoIcon from '@material-ui/icons/Redo';
import IconButton from '@material-ui/core/IconButton';
import Badge from '@material-ui/core/Badge';
import { ThemeProvider, createMuiTheme, TextareaAutosize } from '@material-ui/core'
import TextField from '@material-ui/core/TextField';
import { borderRadius } from '@material-ui/system';
import PropTypes from 'prop-types';
import Tooltip from '@material-ui/core/Tooltip';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
import '../cssFiles/Notes.css';
import AllIconList from './AllIconList'
import UserService from '../Services/UserService/UserService'


var axiosAddnote = new UserService;

export default class Notes extends Component {
  constructor() {
    super()
    this.state = {
      open: false,
      showMe: false,
      notesTitle: '',
      notesDescription: '',

    };

    this.noteAdd = this.noteAdd.bind(this);
    this.onchange = this.onchange.bind(this);
  }

  onchange(e) {
    this.setState({ [e.target.name]: e.target.value });
    console.log(this.state);
  }
  operation = () => {
    this.setState({
      showMe: true,
    });
  };

  operationHide = () => {
    this.noteAdd()
  };

  noteAdd() {
    this.setState({
      showMe: false,
    });
    var data = {

      Title: this.state.notesTitle,
      Description: this.state.notesDescription,
    }

    axiosAddnote.NoteCreate(data).then(response => {
      console.log(" response in ", response);
    })
  }
  render() {
    const { open } = this.state;
    return (
      <div >

      

          <div  className="mainDiv">

            <Card id="cardid" >
              <CardContent>
                <div>

                  <TextareaAutosize id="textfieldTitle"
         
                    multiline
                    InputProps={{ disableUnderline: true }}
                    className="title-text-area" onClick={this.operation} name="notesTitle" onChange={this.onchange} placeholder="Title"
                    contentEditable="true"
                  />

                  {
                    this.state.showMe ?

                      <div>
                        <TextareaAutosize id="textfielddescription"
                        className="note-text-area"
                          multiline
                          InputProps={{ disableUnderline: true }}
                          name="notesDescription" onChange={this.onchange} placeholder="Take A Note"
                          contentEditable="true"
                        />
                   

                       <div className="allIconAndDescDiv">
                         <AllIconList />  
                          <Button className="close-btn-note" onClick={this.noteAdd}>CLOSE</Button>
                        

                      </div>
                      </div>
                      : null
                  }
                </div>

       
                </CardContent>
            </Card>

          </div>

      


      </div>
    )
  }
}