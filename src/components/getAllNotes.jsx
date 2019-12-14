import React, { Component } from 'react'
import Notes from './Notes'
import  DisplayNotes from './DisplayNotes'
import '../cssFiles/getAllNotes.css'
export default class GetAllNote extends Component
 {
    constructor(props){
        super(props);
        this.state={
            AllNotes:[],
            getAllNotes:[]
        }
    }

    getAllNotes=[
        {
            title:'hello',
            description:'firstnotes'
        },
        {
            title:'hello',
            description:'second'
        },
        {
            title:'hello',
            description:'firstnothirdtes'
        },
        {
            title:'hello',
            description:'firstnotes'
        },

    ]

    componentDidMount(){
        this.setState({AllNotes:this.getAllNotes})
    }
    
render(){
    return(
<div  className="notes-top-create">
    <div>
    <Notes/>
    </div>


        <div>
            <DisplayNotes notes={this.getAllNotes}></DisplayNotes>
        </div>
</div>

    )
}
}