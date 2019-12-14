import React from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import '../cssFiles/ForgetPassword.css';
import { ThemeProvider ,createMuiTheme} from '@material-ui/core'


import UserService from '../Services/UserService/UserService'


var forgetService = new UserService ;

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
     
      email:''
    
    
    }

    this.forgetPassword= this.forgetPassword.bind(this);
    this.onchange = this.onchange.bind(this);
  }

  forgetPassword()
  {
    // console.log(this.state);
      var data = {
                 
                  Email: this.state.email                            
                 
                }

                forgetService.SignUpServicesForgetPassword(data).then(response=>{
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
                <h5>Forget Password</h5>
                <label id="label-item"> Use Your Email</label>
                
   <div>
<ThemeProvider theme={theme}>
   
    
<TextField 
              id="text-log"
              label="Email"
              placeholder="Email"            
              margin="normal"
              variant="outlined"
              name="email"
              onChange={this.onchange}
            /> 
            <br/><br/>
               
      </ThemeProvider>

      </div>
      <div className="div-log-forget">
      <Button id="button-sigin"variant="outlined" onClick={this.forgetPassword}>
        Send Mail
      </Button>
     
     
      </div>
  </div>

        )
    }
}