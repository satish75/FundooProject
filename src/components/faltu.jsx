import React, { Component } from 'react'
import Button from '@material-ui/core/Button';
import TextareaAutosize from '@material-ui/core/TextareaAutosize';
import DeleteRoundedIcon from '@material-ui/icons/DeleteRounded';

import Paper from '@material-ui/core/Paper';
import Typography from '@material-ui/core/Typography';
import TextField from '@material-ui/core/TextField';


class faltu extends Component {

    constructor(props) {
        super();

        this.state = {
            allNotes: [{ title: "audi ", note: "testnote - o all sdof " }],
            note: "",
            noteTitle: ""
        }
    }

    onChageNote = (name , value) => {
    
        if (value) {
            this.setState({
                [name]: value
            })
        }
    }

    addNote = (e) => {
        if (this.state.note) {
            let vm = this.state;

            let oldNotes = vm.allNotes;

            let noteObj = {
                title : vm.noteTitle,
                note : vm.note
            }

            oldNotes.push(noteObj);

            

            if (oldNotes) {
                this.setState({
                    allNotes: oldNotes,
                    note: "",
                    noteTitle : ""
                })
            }
        }
    }


    deleteNote = (e, i) => {
        let mylist = this.state.allNotes;
        mylist.splice(i, 1);

        this.setState({
            allNotes: mylist
        })
    }

    displayNoteList = () => {
        let mylist = this.state.allNotes;
        let resultList = mylist.map((obj, index) => {
            return (
                <div key={index} style={{ width : "250px"}}>

                    <Paper >
                        <Typography variant="h5" component="h3">
                            {obj.title}
                            <div style={{ float: "right" }}>
                                <DeleteRoundedIcon onClick={e => this.deleteNote(e, index)} />
                            </div>
                        </Typography>
                        <Typography component="p">
                            {obj.note}
                        </Typography>
                    </Paper>
                </div>
            )
        })

        return resultList;
    }


    render() {



        return (
            <div>
               <TextField id="standard-basic" 
               label="Standard"
               name="noteTitle"
               value={this.state.noteTitle}
               onChange={e => this.onChageNote( e.target.name , e.target.value)}
                />
                <TextareaAutosize
                    aria-label="minimum height"
                    rows={6}
                    placeholder="Minimum 3 rows"
                    name="note"
                    value={this.state.note}
                    onChange={e => this.onChageNote( e.target.name , e.target.value)}
                />

                <br />
                <Button
                    variant="contained"
                    color="primary"
                    onClick={e => this.addNote(e)}
                >
                    Add Note
                  </Button>

                <hr />

                {this.displayNoteList()}

            </div>
        )
    }
}

export default faltu;