import React, { Component } from 'react'
import Notes from './Notes'
import  DisplayNotes from './DisplayNotes'
import '../cssFiles/getAllNotes.css';
import UserService from '../Services/UserService/UserService'
import { Button } from '@material-ui/core';

var getnotes = new UserService;
export default class Archive extends Component
 {
    constructor(props){
        super(props);
        this.state={
            AllNotes:[],
            getAllArchive:[]
        }

        this. getNotesUserArchive = this. getNotesUserArchive.bind(this);
        this.onchange = this.onchange.bind(this);
    }

    componentDidMount(){
     
        this.getNotesUserArchive()
        console.log("this is data")   
    }


    getNotesUserArchive() {
        console.log("This is funtion")

        getnotes.GetNotesArchive().then(response => {
            console.log(response);
            let array = [];
            console.log(" log ",response);
            
            response.data.data.map((data) => {
                array.push(data);
            });
            this.setState({
                getAllArchive: array
            })
           
        });
        console.log('state notes trash array ',this.state.getAllArchive);
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
                        <DisplayNotes notes={this.state.getAllArchive}></DisplayNotes>                     
                        </div>
                </div>

            )
    }
}