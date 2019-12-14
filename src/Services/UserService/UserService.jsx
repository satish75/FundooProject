import axios from 'axios'
import  AxiosService from '../Axios/AxiosService'
var axiosService=new AxiosService;
export default class UserService 
{
    SignUpServices(userData){
        console.log(" data in axios servuixe",userData);
        
        return axiosService.axiosPost(`https://localhost:44338/api/Register/register`,  userData)
    }

    SignUpServicesLogIn(userData){
        console.log(" data in axios servuixe",userData);
        
        return axiosService.axiosPostLogIn(`https://localhost:44338/api/Register/login`,  userData)
    }
    SignUpServicesForgetPassword(userData){
        console.log(" data in axios servuixe",userData);
        
        return axiosService.axiosPostForgetPassword(`https://localhost:44338/api/Register/forgetPassword`,  userData)
    }
    SignUpServicesResetPassword(userData){
        console.log(" data in axios servuixe",userData);
        
        return axiosService.axiosPostResetPassword(`https://localhost:44338/api/Register/resetPassword`,  userData)
    }

    NoteCreate(userData){
        console.log(" data in axios servuixe",userData);
        
        return axiosService.axiosPostAddNote(`https://localhost:44338/api/Notes`,  userData)
    }
    GetNoteAll(userData){
        console.log(" data in axios servuixe",userData);
        
        return axiosService.axiosGetAllNote(`https://localhost:44338/api/Notes`,  userData)
    }
}