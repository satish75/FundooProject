import React, { Component } from 'react'

export default class BottomIconListItem extends Component
{
    render(){
        return(
            <div>

<Tooltip title="Reminder" enterDelay={250} leaveDelay={100}>
                  <IconButton color="black">
              <Badge  color="secondary">
              < AccessAlarmsIcon precision={1}
                
                   className="bottom-icon-list"/>
              </Badge>
            </IconButton>
            </Tooltip>

            <Tooltip title="Collaborate" enterDelay={250} leaveDelay={100}>
                  <IconButton color="black">
              <Badge  color="secondary">
              <PersonAddIcon  className="bottom-icon-list"/>
              </Badge>
            </IconButton>
            </Tooltip>
               

            <Tooltip title="Color" enterDelay={250} leaveDelay={100}>
                  <IconButton color="black">
              <Badge  color="secondary">
              <PaletteIcon  className="bottom-icon-list"/>
              </Badge>
            </IconButton>
            </Tooltip>
                
            <Tooltip title="Image" enterDelay={250} leaveDelay={100}>
                  <IconButton color="black">
              <Badge  color="secondary">
              <ImageIcon  className="bottom-icon-list"/>
              </Badge>
            </IconButton>
            </Tooltip>

            <Tooltip title="Archive" enterDelay={250} leaveDelay={100}>
                   <IconButton color="black">
              <Badge  color="secondary">
              <ArchiveIcon  className="bottom-icon-list"/>   
              </Badge>
            </IconButton>
            </Tooltip>

            
            <Tooltip title="More" enterDelay={250} leaveDelay={100}>
                 <IconButton color="black" onClick={this.toggleDiv}>
              <Badge  color="secondary">
              <MoreVertIcon  className="bottom-icon-list"/>
              </Badge>
            </IconButton>
            </Tooltip>
             
            <Tooltip title="Undo" enterDelay={250} leaveDelay={100}>
                 <IconButton color="black">
              <Badge  color="secondary">
              <UndoIcon  className="bottom-icon-list"/>
              </Badge>
            </IconButton>
            </Tooltip>
               
            <Tooltip title="Redo" enterDelay={250} leaveDelay={100}>
                 <IconButton color="black">
              <Badge  color="secondary">
              <RedoIcon />
              </Badge>
            </IconButton>
            </Tooltip>

            </div>
        )
    }
} 