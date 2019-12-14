
import React, { Component } from 'react';
import { Drawer } from '@material-ui/core';
import { MenuItem } from '@material-ui/core';

class DrawerMenu extends Component {


    constructor(props) {
        super(props);
        this.state = {
            open: false,
            openDialog: false,
            status: false,
            allLabels: [],
            trash: false
        }


    }




  


    // handleClickOpen(){
    //     this.setState({
    //         openDialog: !this.openDialog,
    //     })

    // }
  


  

    render() {

        console.log(" this ",this.props.appBarProps);
        
        return (
            <div className="bg-color">
                <Drawer
                    variant="persistent"
                   // open={this.props.appBarProps}
                    width={200}
                >
                    <MenuItem //onClick={this.handleNotes}
                        style={{ borderRadius: "0 25px 25px 0", backgroundColor: (this.state.trash) ? "#feefc3" : null }}>
                        <img className="update-card-img"
                        
                            alt="color picker" />
                        <span className="fundoo-text-sidebar">Notes</span>
                    </MenuItem>

                    <MenuItem //onClick={this.handleReminder} className="MuiMenuItem-gutters"
                        style={{ borderRadius: "0 25px 25px 0", backgroundColor: (this.state.trash) ? "#feefc3" : null }}>
                        <img className="update-card-img"
                           
                            alt="reminder" />
                        <span className="fundoo-text-sidebar">Reminders
                        </span>
                    </MenuItem>
                    <div style={{ borderBottom: "1px solid lightgrey", borderTop: "1px solid lightgrey" }}>
                        <div style={{ marginRight: "218px", fontSize: "12px", marginBottom: "10px", marginTop: "10px", fontFamily: "arial" }}>
                           
                        </div>
                        <div>
                          
                          


                            <MenuItem
                                //onClick={this.handleLabelOpen}
                                className="drawer-links"
                            >
                               
                            </MenuItem>
                        </div>
                    </div>

                    <MenuItem //onClick={this.handleArchived}
                        className="MuiMenuItem-gutters"
                        style={{ borderRadius: "0 25px 25px 0", backgroundColor: (this.state.trash) ? "#feefc3" : null }}>
                        <img className="update-card-img"
                           
                            alt="color picker" />
                        <span className="fundoo-text-sidebar">Archive</span>
                    </MenuItem>

                    <MenuItem //onClick={this.handleTrashed}
                        className="MuiMenuItem-gutters"
                        style={{ borderRadius: "0 25px 25px 0", backgroundColor: (this.state.trash) ? "#feefc3" : null }}>
                        <img className="update-card-img"
                        
                            alt="color picker" />
                        <span className="fundoo-text-sidebar">Trash</span>
                    </MenuItem>

                </Drawer>
            </div>
        )
    }
}

export default (DrawerMenu)
