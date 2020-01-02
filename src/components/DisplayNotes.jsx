import React from 'react'
import Card from '@material-ui/core/Card';
import '../cssFiles/DisplayNotes.css';
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
import { ThemeProvider, createMuiTheme, TextField } from '@material-ui/core'
import TextareaAutosize from '@material-ui/core/TextareaAutosize';
import { borderRadius } from '@material-ui/system';
import PropTypes from 'prop-types';
import Tooltip from '@material-ui/core/Tooltip';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
import AllIconList from './AllIconList'
import NoteCard from './NoteCard'
import Collaborator from './Collaborator'
import ChangeColor from './ChangeColor'
import Avatar from '@material-ui/core/Avatar';
import ArchiveIconComponent from './ArchiveIconComponent'
import Reminder from './Reminder'
import Dialog from "@material-ui/core/Dialog";
import EditLocationOutlinedIcon from "@material-ui/icons/EditLocationOutlined";
import { MuiThemeProvider } from "@material-ui/core";
import Update from './Update'
import UserService from '../Services/UserService/UserService'

import '../images/pic1.jpg'
var axioxUpdate = new UserService();
const theme = createMuiTheme({
  overrides: {
    MuiBackdrop: {
      root: {
        backgroundColor: "transperent"
      }
    },
  }
});


export default class DisplayNotes extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      notes: [],
      showCard: false,
    
      Title: '',
      Description: '',
      noteTitle: '',
      noteDescription: ''

    }
    this.UpdateNotes = this.UpdateNotes.bind(this)
  }
  onchange(e) {
    this.setState({ [e.target.name]: e.target.value });
    console.log(this.state);
  }

  operation = (item) => {
    this.setState({
      showCard: true,
      noteTitle: item.title,
      noteDescription: item.description
    });
  };

  operationHide = () => {
    this.setState({
      showCard: false,

    });
  };

  getUpdateValue = (event) => {
    console.log(event.target);

    this.setState({
      [event.target.name]: event.target.value
    });
    // console.log("notes title value in Update ",this.state.notesTitle);

  };

  UpdateNotes() {
    var data = {
      TitleNote: this.state.Title,
      DescriptionNote: this.state.Description,
    }
    axioxUpdate.UpdateNotesService(data).then(response => {
      console.log(" response in ", response);
    })
    this.operationHide();
  }

  handleSave = () => {
    this.props.refresh()
  }

  render() {
    console.log(" print all  Title colorrrrr ", this.state.noteTitle);
    console.log(" print all  Description colorrrrr ", this.state.noteDescription);
    var printNoteList = this.props.notes.map((item, index) => {
      return (
        <div className="card">

          <Card id="cardIdAllNotes" style={{ backgroundColor: item.color }} >

            <CardContent>
              <div>
                <TextareaAutosize id="titlefield"
                  // style={{ backgroundColor: item.color }}

                  name="notesTitle"
                  onChange={this.onchange}
                  placeholder="Title"
                  InputProps={{ disableUnderline: true }}
                  onClick={() => this.operation(item)}
                  value={item.title} />

                <div>
                  <TextareaAutosize id="textdescription"
                    // style={{ backgroundColor: item.color }}
                    className="note-text-area"
                    name="notesDescription"
                    onChange={this.onchange}
                    placeholder="Take A Note"
                    onClick={() => this.operation(item)}
                    value={item.description} />
                  <div>
                  </div>
                  <Tooltip title="satishdodake100@gmail.com" enterDelay={250} leaveDelay={100}>
                    <IconButton color="black" src="C:\\Users\\bridgeit\\Downloads\\pic1.jpg">
                      <Avatar src="images\pic1.jpg" className="propfilePic" />
                    </IconButton>
                  </Tooltip>

                  <div id="allIconDivList">
                    <Reminder />
                    <Collaborator idItem={item.id} />
                    <ArchiveIconComponent noteid={item.id} />
                    <ChangeColor idItem={item.id} colorBack={item.color} save={this.handleSave} />
                  </div>
                </div>
              </div>
            </CardContent>
          </Card>
        </div>

      )
    })

    return (
      <div id="printAllNotesDiv"
      >
        {printNoteList}
        {this.state.showCard === true ?
          <div>
              <Update title={this.state.noteTitle} desc={this.state.noteDescription} />
          </div>
          :null}
      </div>


    )
  }
}