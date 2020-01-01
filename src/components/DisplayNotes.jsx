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
import '../images/pic1.jpg'


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
      open:false,
      Title:'',
      Description:''

    }
  }
  onchange(e) {
    this.setState({ [e.target.name]: e.target.value });
    console.log(this.state);
  }

  operation = (item) => {
    this.setState({
      showCard: true,
      Title:item.title,
      Description:item.description
    });
  };
  
  handleSave = () => {
    this.props.refresh()
  }

  // openDialog = () =>{
  //   this.setState({
  //     open: !this.state.open,
  //   });
  // }
  render() {
    console.log(" print all  Title colorrrrr ", this.state.Title);
    console.log(" print all  Description colorrrrr ", this.state.Description);



    var printNoteList = this.props.notes.map((item, index) => {


      return (
        <div className="card">

          <Card id="cardIdAllNotes" style={{ backgroundColor: item.color }} >

            <CardContent>
              <div>
                <TextareaAutosize id="titlefield"
                  style={{ backgroundColor: item.color }}

                  name="notesTitle"
                  onChange={this.onchange}
                  placeholder="Title"
                  InputProps={{ disableUnderline: true }}
                  onClick={()=> this.operation(item)}
                  value={item.title} />

                <div>
                  <TextareaAutosize id="textdescription"
                    style={{ backgroundColor: item.color }}
                    className="note-text-area"
                    name="notesDescription"
                    onChange={this.onchange}
                    placeholder="Take A Note"
                    contentEditable="true"
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

          <div>  
          <MuiThemeProvider theme={theme}>      
          <Dialog id="Dialog"  open={this.state.showCard}   >
            <div id="Update-UpdateNotesCardInner"  style={{backgroundColor:this.state.color}}>
                                  
                <div  style={{backgroundColor:item.color}}>
                  <div className="Update-NotesTitleAndDesc"  style={{backgroundColor:this.state.color}}>
                    <TextareaAutosize 
                      id="UpdateNotetitleId"
                      name="notesTitle"
                      value={this.state.Title} 
                      placeholder="NoteTitle"   
                      onClick={this.operation}
                       style={{backgroundColor:this.state.color}}
                    />
                    <EditLocationOutlinedIcon />
                    <br/>
                    <TextareaAutosize
                      id="UpdateNoteDescriptionId"
                      name="notesDescription"
                      value={this.state.Description} 
                      onClick={this.operation}

                      placeholder="Description"
                       style={{backgroundColor:this.state.color}}
                    />
                  </div>

                  <div className="Small-closeButton">
                    
              <div className="Small-closeButton"  style={{backgroundColor:this.state.color}}>
                    <Reminder noteid={item.id}/>
                    <Collaborator idItem={item.id} />
                    <ArchiveIconComponent noteid={item.id} />
                    <ChangeColor idItem={item.id} colorBack={item.color} save={this.handleSave} />
              </div>
                    
                    <Button onClick={this.operationHide} style={{backgroundColor:this.state.color}}>Close</Button>
                  </div>
                </div>
            </div>
          </Dialog>
       </MuiThemeProvider>
          </div>

        </div>




      )
    })

    return (
      <div id="printAllNotesDiv"
      >

        {printNoteList}
      </div>


    )
  }
}