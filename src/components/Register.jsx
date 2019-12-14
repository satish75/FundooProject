import React from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';

import '../cssFiles/register.css';
import InputLabel from '@material-ui/core/InputLabel';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';
import PopupState, { bindTrigger, bindMenu } from 'material-ui-popup-state';

import UserService from '../Services/UserService/UserService'
import { ThemeProvider ,createMuiTheme} from '@material-ui/core'

var signUpService = new UserService ;

const theme = createMuiTheme({
   
    overrides:{
        MuiInputLabel:{
            formControl:{
                top:"-9px"
            }
        },


        MuiInputBase:{
            root:{
                height:"35px"
                
            }
        },
        MuiFormControl:{
            marginNormal:{
              marginLeft:"20px"
            }
        }
    }
  });


export default class Register extends React.Component{

  constructor(props)
  {
    super(props);

    this.state= {
      firstName:'',
      lastName:'',
      userName:'',
      password:'',
      email:'',
      serviceType:''
    }

    this.signUp= this.signUp.bind(this);
    this.onchange = this.onchange.bind(this);
  }

  signUp()
  {
    // console.log(this.state);
      var data = {
                  FirstName: this.state.firstName, 
                  LastName: this.state.lastName,
                  UserName: this.state.userName,                             
                  Password : this.state.password,
                  Email:this.state.email,
                  ServiceType: this.state.serviceType}

                  signUpService.SignUpServices(data).then(response=>{
                    console.log(" response in ",response);
                    
                  })
  }

  onchange(e)
  {
    this.setState({[e.target.name]: e.target.value});
    console.log(this.state);
  }

    render(){

        return(

            <div className="div-log-in" id="div-id">
               
                <h2>Sign Up</h2>            
               
                
   <div>
<ThemeProvider theme={theme}>
   
    
<TextField 
              id="text-log-in"
              label="FirstName"
              placeholder="FirstName"            
              margin="normal"
              name="firstName"
              onChange={this.onchange}
              variant="outlined"
     
            /> 
            
 <TextField 
              id="text-log-in"
              label="LastName"
              placeholder="LastName"            
              margin="normal"
              variant="outlined"
              name="lastName"
              onChange={this.onchange}
     
            /> 
 
   
               
 <TextField 
              id="text-log-in"
              label="UserName"
              placeholder="UserName"            
              margin="normal"
              variant="outlined"
              name="userName"
              onChange={this.onchange}
     
            /> 

   
           
<TextField 
              id="text-log-in"
              label="Email"
              className="email"
              placeholder="Email"            
              margin="normal"
              variant="outlined"
              name="email"
              onChange={this.onchange}
     
            />               

<TextField
            variant="outlined"
            margin="normal"
            required
        
            name="password"
            label="Password"
            type="password"
            id="text-log-in"
            autoComplete="current-password"
            name="password"
            onChange={this.onchange}
          />            

     
<TextField
            variant="outlined"
            margin="normal"
            required
        
            name="passwordConfirm"
            label="Confirm"
            type="password"
            id="text-log-in"
            autoComplete="current-password"
            name="confirm"
            onChange={this.onchange}
          />         
 
     
      </ThemeProvider>

     


      </div>
      <div className="div-log-forget">

      

      <Button id="button-sigin"variant="outlined" onClick={this.signUp}>
       Register
      </Button>
     
      <PopupState variant="popover" popupId="demo-popup-menu">
      {popupState => (
        <React.Fragment>
          <Button variant="contained" color="primary" {...bindTrigger(popupState)} id="service-type">
           Service Type
          </Button>
          <Menu {...bindMenu(popupState)}>
            <MenuItem onClick={popupState.close}>basic</MenuItem>
            <MenuItem onClick={popupState.close}>advance</MenuItem>
          </Menu>
        </React.Fragment>
      )}
    </PopupState>
      </div>
  </div>

        )
    }
}