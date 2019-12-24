import React, { Component } from 'react'
import Notes from './Notes'
import  DisplayNotes from './DisplayNotes'
import '../cssFiles/getAllNotes.css';
import UserService from '../Services/UserService/UserService'
import { Button } from '@material-ui/core';

var getnotes = new UserService;
export default class Trash extends Component
 {
    constructor(props){
        super(props);
        this.state={
            AllNotes:[],
            getAllNotesTrash:[]
        }

        this. getNotesUserTrash = this. getNotesUserTrash.bind(this);
        this.onchange = this.onchange.bind(this);
    }

    componentDidMount(){
     
        this.getNotesUserTrash()
        console.log("this is data")   
    }


    getNotesUserTrash() {
        console.log("This is funtion")

        getnotes.GetNotesTrash().then(response => {
            console.log(response);
            let array = [];
            console.log(" log ",response);
            
            response.data.data.map((data) => {
                array.push(data);
            });
            this.setState({
                getAllNotesTrash: array
            })
           
        });
        console.log('state notes trash array ',this.state.getAllNotesTrash);
    }

  onchange(e)
  {
    this.setState({[e.target.name]: e.target.value});
    console.log(this.state);
  }
render()
    {
    return(
                <div>        
                        <div >
                        <DisplayNotes notes={this.state.getAllNotesTrash}></DisplayNotes>                     
                        </div>
                </div>

            )
    }
}