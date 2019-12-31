import React, { Component } from 'react'
import '../cssFiles/getAllNotes.css';
import UserService from '../Services/UserService/UserService'
import { Button, TextField } from '@material-ui/core';
import Demo from './demo';
import DashBoard from './DashBoard'



var getnotes = new UserService;
export default class EditLabel extends Component {
    constructor(props) {
        super(props);
        this.state = {
            AllLabel: [],
            getAllLabel: [],
            labelValue:'',
            name:this.props.labeldata
           
        }

        this.getLabelsNotes = this.getLabelsNotes.bind(this);
       
    }

    componentDidMount() {

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
     
//     ChangeData = async (data) =>
//     {
//    await this.setState({
//     labelValue:data
// })
// console.log("new data ",this.state.labelValue);

//     }

handleChange = name => event => {
    this.setState({ [name]: event.target.value });
  };
    render() {

console.log("name edit ",this.props.labeldata);
console.log("state with name edit ",this.state.name);


      
            return (
                <div>              
                 <TextField
                          id="standard-name"
                          value={this.state.name}
                          onChange={this.handleChange('name')}
                          margin="normal"
                        /> 
                      
                   <div>
              
                   </div>
                </div>

            
        )

    }
}