import React, { Component } from 'react'
import '../cssFiles/getAllNotes.css';
import UserService from '../Services/UserService/UserService'
import { Button, TextField } from '@material-ui/core';
import Demo from './demo';
import DashBoard from './DashBoard'
import EditLabel from './EditLabel'
import NotesOnLabel from './NotesOnLabel'

var getnotes = new UserService;
export default class Labeldata extends Component {
    constructor(props) {
        super(props);
        this.state = {
            AllLabel: [],
            getAllLabel: [],
            labelValue: '',
            name: ''
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
        console.log("edit dashboard ", this.props.editLabelbool);

        var printNoteList = this.state.getAllLabel.map((item, index) => {
            const datalabel = item.label
            console.log('data label value Id ');
            return (
                <div>

                    {
                        this.props.editLabelbool === false ? <Button id="span-id-label">{item.label} </Button> :
                        <EditLabel labeldata={item.label} labelId={item.idLabel} />
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