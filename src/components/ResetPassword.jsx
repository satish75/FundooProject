import React from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import '../cssFiles/ForgetPassword.css';
import { ThemeProvider ,createMuiTheme} from '@material-ui/core'


import UserService from '../Services/UserService/UserService'


var resetService = new UserService ;

const theme = createMuiTheme({
   
    overrides:{
        MuiInputLabel:{
            formControl:{
                top:"-9px"
            }
        },


        MuiInputBase:{
            root:{
                height:"50px"
                
            }
        },
        MuiFormControl:{
            marginNormal:{
              marginLeft:"20px"
            }
        }
    }
  });

export default class ForgetPassword extends React.Component{

  constructor(props)
  {
    super(props);

    this.state= {
     
      password:'',
     
    
    }

    this.resetPassword= this.resetPassword.bind(this);
    this.onchange = this.onchange.bind(this);
  }

  resetPassword()
  {
    // console.log(this.state);
      var data = {
                 token:this.props.match.params.token,
                  Password: this.state.password                                       
                }
                
   console.log(data)
                resetService.SignUpServicesResetPassword(data).then(response=>{
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

            <div className="div-log" id="div-id">
               
                <h2>Fundoo</h2>            
                <h5>Reset Password</h5>
                <label id="label-item"> Use Your Email</label>
             
                
   <div>
<ThemeProvider theme={theme}>
   
    
<TextField 
              id="text-log"
              label="Password"
              placeholder="New Password"            
              margin="normal"
              variant="outlined"
              name="password"
              onChange={this.onchange}
            /> 
            <br/><br/>
               
      </ThemeProvider>

      </div>
      <div className="div-log-forget">
      <Button id="button-sigin"variant="outlined" onClick={this.resetPassword}>
       Reset Password
      </Button>
       
      </div>
  </div>

        )
    }
}