import React, { Component } from 'react'
import '../cssFiles/getAllNotes.css';
import UserService from '../Services/UserService/UserService'
import { Button, TextField } from '@material-ui/core';
import Demo from './demo';
import DashBoard from './DashBoard'



var getnotes = new UserService;
export default class Labeldata extends Component {
    constructor(props) {
        super(props);
        this.state = {
            AllLabel: [],
            getAllLabel: [],
            labelValue:''
        }

        this.getLabelsNotes = this.getLabelsNotes.bind(this);
        this.ChangeData = this.ChangeData.bind(this);
    }

    componentWillMount() {

        this.getLabelsNotes()
        console.log("this is data label")
    }


    getLabelsNotes() {
        console.log("This is funtion")

        getnotes.GetLabelService().then(response => {
            console.log(response);
            let array = [];
            console.log(" log ", response);

            response.data.data.map((data) => {
                array.push(data);
            });
            this.setState({
                getAllLabel: array
            })

        });

    }
     
    ChangeData = async (data) =>
    {
   await this.setState({
    labelValue:data
})
console.log("new data ",this.state.labelValue);

    }

      onchange(e)
      {
        this.setState({[e.target.name]: e.target.value});
        console.log(this.state);
      }
    render() {

        var printNoteList = this.state.getAllLabel.map((item, index) => {
              var datalabel=item.label
              console.log('data label value ', datalabel);
            return (
                <div>
                 
                        {
                          this.props.labelbool === true ?   <TextField name="labeldata" onChange={(event)=> this.ChangeData(event)}  value={item.label} />
                          : <Button  id="span-id-label">{item.label} </Button>
                         
                        }
              
                   <div>
              
                   </div>
                </div>

            )
        })

        return (
            <div>
                {printNoteList}
            </div>
        )
    }
}