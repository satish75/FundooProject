import React, { Component } from 'react'
import Notes from './Notes'
import  DisplayNotes from './DisplayNotes'
import '../cssFiles/getAllNotes.css';
import UserService from '../Services/UserService/UserService'
import { Button } from '@material-ui/core';

var getnotes = new UserService;
export default class GetAllNotes extends Component
 {
    constructor(props){
        super(props);
        this.state={
            AllNotes:[],
            getAllNotes:[]
        }

        this. getNotesUser = this. getNotesUser.bind(this);
        this.onchange = this.onchange.bind(this);
    }

    componentDidMount(){
     
        this.getNotesUser()
        console.log("this is data")
       
    }
    getNotesUser() {
        console.log("This is funtion")

        getnotes.GetNotesService().then(response => {
            console.log(response);
            let array = [];
            console.log(" log ",response);
            
            response.data.result.map((data) => {
                array.push(data);
            });
            this.setState({
                getAllNotes: array
            })
           
        });
        console.log('state notes array ',this.state.getAllNotes);
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
                        <Notes/>
                        </div>
                        
                        <div >
                        <DisplayNotes notes={this.state.getAllNotes} refresh={this.getNotesUser}></DisplayNotes>                     
                        </div>
                </div>

            )
    }
}