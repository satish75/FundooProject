import React from 'react';
import Badge from '@material-ui/core/Badge';
import Tooltip from '@material-ui/core/Tooltip';
import { IconButton } from "@material-ui/core";
import ImageOutlinedIcon from '@material-ui/icons/ImageOutlined';

import UserService from '../Services/UserService/UserService'


var axiosObject = new UserService();
export default class Image extends React.Component {

    constructor(props) {
        super(props);
        this.state = {
            pictures: null,
            openImageSelector: false,
            noteId: this.props.noteId,
        };


    }

    opened = () => {
        this.setState({
            openImageSelector: !this.state.openImageSelector
        })
    }

    ImageHandler = event => {
        this.setState({
            pictures: event.target.files[0],

        }, () => {
            this.UploadImage();
        });
    }

    UploadImage = () => {


        var imageData = new FormData();
        imageData.append('file', this.state.pictures)
        console.log('Append result', imageData);
        axiosObject.ImageUploadService(this.state.noteId, imageData).then(response => {
            console.log('response of image', response);
            this.props.refresh();
        })
    }
    render() {
        console.log('Image name', this.state.pictures);

        return (
            <div >

                <Tooltip title="Image" enterDelay={250} leaveDelay={100}>
                    <IconButton size="small" color="black" onClick={this.opened}  >
                        <Badge color="secondary">
                            <ImageOutlinedIcon fontSize="inherit" />
                        </Badge>
                    </IconButton>
                </Tooltip>

                {
                    this.state.openImageSelector === true ?
                        <input type="file" onChange={this.ImageHandler} /> : null
                }
            </div>

        );
    }
}