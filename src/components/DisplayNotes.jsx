import React from 'react'
import Card from '@material-ui/core/Card';
import '../cssFiles/DisplayNotes.css';

export default class DisplayNotes extends React.Component{

    constructor(props){
        super(props);
        this.state={
            notes:[]

        }
    }
    render(){
        console.log(" print all  notes i display ",this.props.notes);
       

       var  printNoteList=  this.props.notes.map( (key)=>{
        //    console.log(" key ",key.title);
        
                return(
                    <div>                 
                        <Card className="card-content-notes">
                          tgdfged
                            <h1>{key.title}</h1>
                            <h6>{key.description}</h6>
                        </Card>
                       
                    </div>
                    )
                    })
        return(
            <div>
                {printNoteList}
            </div>
        )
    }
}