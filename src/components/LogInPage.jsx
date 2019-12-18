import React from 'react';
import TextField from '@material-ui/core/TextField';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';

import '../cssFiles/LogInPage.css';
import { ThemeProvider ,createMuiTheme} from '@material-ui/core'


import UserService from '../Services/UserService/UserService'


var logInService = new UserService ;

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

export default class LogInPage extends React.Component{



  constructor(props)
  {
    super(props);

    this.state= {
     
      userName:'',
      password:'',
      products: []
    
    }


    this.logIn= this.logIn.bind(this);
    this.onchange = this.onchange.bind(this);
  }

  logIn()
  {
    // console.log(this.state);
      var data = {
                 
                  UserName: this.state.userName,                             
                  Password : this.state.password,

                }

                logInService.SignUpServicesLogIn(data).then(response=>{
                    console.log(" response in ",response);
                    localStorage.setItem('token',response.data.token)
                    
                  })
  }

  onchange(e)
  {
    this.setState({[e.target.name]: e.target.value});
    console.log(this.state);
  }



    render(){
      const { products} = this.state;
        return(

            <div className="div-log" id="div-id">
               
                <h2>Fundoo</h2>            
                <h5>SignIn</h5>
                <label id="label-item"> Use Your Fundoo Account</label>
                
   <div>
<ThemeProvider theme={theme}>
   
    
<TextField 
              id="text-log-in"
              label="UserName"
              placeholder="UserName"            
              margin="normal"
              variant="outlined"
              name="userName"
              onChange={this.onchange}
            /> 
            <br/><br/>
            
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
      </ThemeProvider>

      </div>
  <br/><br/>
      <Button id="button-log"variant="outlined" onClick={this.logIn}>
        LogIn
      </Button>
     
      <Link href="http://localhost:3000/forget" id="link-forget" underline="none">
        Forget Password?
      </Link>
     
     
  </div>

        )
    }
}