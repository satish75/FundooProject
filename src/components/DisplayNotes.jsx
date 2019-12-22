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
import { ThemeProvider ,createMuiTheme, TextField} from '@material-ui/core'
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
export default class DisplayNotes extends React.Component{

    constructor(props){
        super(props);
        this.state={
            notes:[],
            showCard:false

        }
    }
    onchange(e)
    {
      this.setState({[e.target.name]: e.target.value});
      console.log(this.state);
    }

    operation = () => {
      this.setState({
        showCard: true,
      });
    };


    render(){
        console.log(" print all  notes i display ",this.props.notes);
       

       var  printNoteList=  this.props.notes.map( (item,index)=>{
        
        
                return(
                     <div className="card">              
                    <Card id="cardIdAllNotes" onClick={this.operation} >
                      {
                        this.state.showCard ? 
                        <NoteCard /> : 

                        <CardContent>
                        <div>
        
                          <TextareaAutosize id="titlefield"
                 
                 
                               name="notesTitle"  
                               onChange={this.onchange} 
                               placeholder="Title" 
                               InputProps={{disableUnderline:true}}
                              value={item.title} />
        
                              <div>
                                <TextareaAutosize id="textdescription"
                                className="note-text-area"
                                name="notesDescription" 
                                 onChange={this.onchange} 
                                placeholder="Take A Note"
                                contentEditable="true"
                                   value={item.description} />
   
                            
                                 <AllIconList />  
                                  
                              </div>
                       
                          
                        </div>
        
               
                        </CardContent>
              
                      }

                         </Card>
                  </div>
         
  
                          
             
          )
          })
      
      return(
     <div  id={ !true ? "printAllNotesDivOpenMenu" : "printAllNotesDiv"}
     >
        
         {printNoteList}        
     </div>
         
         
        )
    }
}