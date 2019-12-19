import React from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import '../cssFiles/register.css';
import InputLabel from '@material-ui/core/InputLabel';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';
import PopupState, { bindTrigger, bindMenu } from 'material-ui-popup-state';
import Radio from '@material-ui/core/Radio';
import UserService from '../Services/UserService/UserService'
import { ThemeProvider ,createMuiTheme} from '@material-ui/core'


import '../cssFiles/register.css'
var signUpService= new UserService;

const theme = createMuiTheme({
   
    overrides:{
        MuiInputLabel:{
            formControl:{
                top:"-9px"
            }
        },


        MuiInputBase:{
            root:{
                height:"35px",                            
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
      UserName:'',
      Password:'',
      ServiceType:''
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
                  UserName: this.state.UserName,                             
                  password : this.state.Password,
                  ServiceType: this.state.ServiceType}

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
              id="text-log-userName"
              label="UserName"
              placeholder="UserName"            
              margin="normal"
              name="UserName"
              onChange={this.onchange}
              variant="outlined"
     
            />     
        <TextField 
              id="text-log-in"
              label="ServiceType"
              placeholder="ServiceType"            
              margin="normal"
              name="ServiceType"
              onChange={this.onchange}
              variant="outlined"
     
            />          

<TextField 
              id="text-log-in"
              label="Password"
              placeholder="Password"            
              margin="normal"
              name="Password"
              onChange={this.onchange}
              variant="outlined"
     
            /> 

      </ThemeProvider>

      </div>
     
      <div className="div-log-forget">
      <br/>
      <Button id="button-sigin"  onClick={this.signUp}>
       Register
      </Button>
     
     
      </div>
  </div>

        )
    }
}