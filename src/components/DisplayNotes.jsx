import React from 'react'
import Card from '@material-ui/core/Card';
import '../cssFiles/DisplayNotes.css'
export default class DisplayNotes extends React.Component{

    constructor(props){
        super(props);
        this.state={
            notes:[]

        }
    }


    componentDidMount() {
        const apiUrl = 'https://localhost:44303/api/Notes';
    
        fetch(apiUrl)
          .then(res => res.json())
          .then(
            (result) => {
              this.setState({
                notes: result
              });
            }
          )
      }
    render(){
        const { notes} = this.state;

        console.log(" print all  notes i display ",this.props.notes);
        

       var  printNoteList=  this.props.notes.map((key)=>{
        //    console.log(" key ",key.title);
           
                return(
                    <div>                                
          <Card id="card-content-item"> 
                {notes.map(noteData => (
                key=noteData.UserId,
                  noteData.Title,
                  noteData.Description,       
                  noteData.Color
   ))
   } 
      <br/>
    </Card>
      </div>
   ) })

        return(
            <div>
                {printNoteList}
            </div>
        )
    }
}