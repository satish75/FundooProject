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
import { ThemeProvider ,createMuiTheme} from '@material-ui/core'
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

export default class DisplayNotes extends React.Component{

    constructor(props){
        super(props);
        this.state={
            notes:[]

        }
    }
    onchange(e)
    {
      this.setState({[e.target.name]: e.target.value});
      console.log(this.state);
    }




    render(){
        console.log(" print all  notes i display ",this.props.notes);
       

       var  printNoteList=  this.props.notes.map( (key)=>{
            console.log(" key ",key.title);
        
                return(
                                   
           <div >
         
              <Card className="div-card">
               <CardContent >   

                     <TextareaAutosize  className="title-and"
                      name="notesTitle"  
                      onChange={this.onchange} 
                      placeholder="Title" 
                     value={key.title} />

       
                                                          
          <TextareaAutosize className="note-and"
           aria-multiline="true"
            name="notesDescription" 
            onChange={this.onchange} 
            placeholder="Take A Note"
            contentEditable="true"
            value={key.description} />
                                   
            
              <AllIconList/>
              </CardContent>        
              </Card>
                <br/>
              </div>              
             
          )
          })
      
      return(
            <div className="print-all-notes">
                {printNoteList}
            </div>
        )
    }
}