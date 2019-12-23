import axios from 'axios';

export default class AxiosService  {

    
    axiosPost(url,data){
         
        return axios.post(url,  data)
    }
      
    axiosPostLogIn(url,data){
         console.log('data in axios service',url,data)
        return axios.post(url,  data)
    }
    axiosPostForgetPassword(url,data){
         
        return axios.post(url,  data)
    }
    axiosPostResetPassword(url,data){
         
        return axios.post(url,  data)
    }
       
    axiosPostAddNote(url,data){
         console.log('dvvvvr')
         var token=localStorage.getItem('token')
         console.log("this is token",token)
         var header=""
        return axios.post(url,data,{
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer '+token
            },      
        }     )
    }
    axiosGetAllNote(url,data){
         console.log("header axios ",data)
         var token=localStorage.getItem('token')
        return axios.get(url,{header :{Authorization: `bearer ${token}`}})
    }
        axiosDeleteNote(url,data)
            {
                var token=localStorage.getItem('token')
                return axios.delete(url,data,{header :{Authorization: `bearer ${token}`}})
            }      
            
            
           
    }