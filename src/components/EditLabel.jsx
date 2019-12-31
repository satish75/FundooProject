import React, { Component } from 'react'
import '../cssFiles/getAllNotes.css';
import UserService from '../Services/UserService/UserService'
import { Button, TextField, IconButton } from '@material-ui/core';
import Demo from './demo';
import DashBoard from './DashBoard'
import EditIcon from '@material-ui/icons/Edit';
import DeleteIcon from '@material-ui/icons/Delete';

var getnotes = new UserService;
export default class EditLabel extends Component {
    constructor(props) {
        super(props);
        this.state = {
            AllLabel: [],
            getAllLabel: [],
            labelValue: '',
            name: this.props.labeldata

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

    handleChange = name => event => {
        this.setState({ [name]: event.target.value });
    };
    render() {

        console.log("name edit with label ", this.props.labeldata.label);
        console.log("this is Id of label ", this.props.labelId);
        return (
            <div>
             <IconButton>
            <DeleteIcon />
           </IconButton>

                <TextField
                    id="standard-name"
                    value={this.state.name}
                    onChange={this.handleChange('name')}
                    margin="normal"
                />
                <IconButton >
                    <EditIcon />
                </IconButton>
                <div>
                </div>
            </div>
        )

    }
}