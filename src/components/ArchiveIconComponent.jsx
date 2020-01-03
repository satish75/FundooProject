import React, { Component } from 'react';
import ArchiveIcon from '@material-ui/icons/Archive';
import Tooltip from '@material-ui/core/Tooltip';
import IconButton from '@material-ui/core/IconButton';
import UnarchiveOutlinedIcon from '@material-ui/icons/UnarchiveOutlined';
import UserService from '../Services/UserService/UserService'

var axiosObject = new UserService;
export default class ArchiveIconComponent extends Component {

  ArchiveNotes = () => {
    // console.log('this is delete note function', this.props )
    var id = this.props.noteid
    console.log('Archive note id in Archive()', id)


    axiosObject.ArchiveIconService(id).then(response => {
      console.log(" response in ", response);
    })

      .catch(error => {
        console.log('def', error.response)
      });
  }


  render() {
    return (
      <div className="Archive-top-div">

           <Tooltip title="Archive">
            <IconButton size="small" onClick={this.ArchiveNotes} color="black">
              <UnarchiveOutlinedIcon fontSize="inherit" />
            </IconButton>
          </Tooltip>
      </div>
    )
  }

}
