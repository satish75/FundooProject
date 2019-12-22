import React, { Component } from 'react';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import Button from '@material-ui/core/Button';
import Badge from '@material-ui/core/Badge';
import { ThemeProvider ,createMuiTheme} from '@material-ui/core'
import TextareaAutosize from '@material-ui/core/TextareaAutosize';
import { borderRadius } from '@material-ui/system';
import PropTypes from 'prop-types';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
import AllIconList from './AllIconList'
import '../cssFiles/NoteCard.css';
import EditLocationOutlinedIcon from '@material-ui/icons/EditLocationOutlined';



export default class NoteCard extends Component
{
  constructor(props)
  {
    super(props)
    this.state = {
        open: false,
        showMe: false,
        notesTitle:'',
        notesDescription:'' ,
        NotesInfo:[],
      };

      
   
    this.onchange = this.onchange.bind(this);
  }

    closeMePopup = () =>{
        return false;
    }
    
    onchange(e)
    {
      this.setState({[e.target.name]: e.target.value});
       console.log(this.state);
    }
      
    render(){
      console.log('NoteCard',this.props.NotesInfo)
        const { open } = this.state;
        return(
            <div className="CardNoteDiv"> 
                
            <div className="NotesCard-div" >
          
               <Card id = "UpdateCard">
                    <div className="titleAndDescription">
                         < EditLocationOutlinedIcon 
                         id="pin"
                          />
                     <TextareaAutosize id="titleId" 
                       name="notesTitle"
                        onChange={this.onchange}
                         placeholder="Title"
                         value={this.props.title}
                         />                           
                        <TextareaAutosize id="DescriptionId" 
                           name="notesTitle" 
                           onChange={this.onchange}
                           onClick={this.operation} 
                           placeholder="Description" 
                           value={this.props.desc}
                          />
                    </div>

                            <div  className="closeButton">
                                <div>
                                        <AllIconList />
                                </div>
                                <div>
                                    <Button
                                    onClick={this.closeMePopup()}>Close</Button>              
                                </div>
                            </div>
                </Card>                 
              </div>
          </div>
        )
    }
}