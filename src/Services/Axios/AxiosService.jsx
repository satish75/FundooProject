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
         
        return axios.post(url,  data)
    }
    axiosGetAllNote(url,data){
         console.log("header axios ",data)
         var token=localStorage.getItem('token')
        return axios.get(url,{header :{Authorization: `beaer ${token}`}})
    }
                   
    }