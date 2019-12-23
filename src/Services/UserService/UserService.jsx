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
        console.log(" data in axios User ",userData);
        
        return axiosService.axiosPostAddNote(`https://localhost:44338/api/Notes`,  userData)
    }
    GetNotesService()
    {
        console.log("GetNotesService");
       
        var JwtToken = localStorage.getItem('token')
       console.log("This is get notes service", JwtToken);
        return axios.get(`https://localhost:44338/api/Notes`, {
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }

    DeleteNotesService(Id)
    {
        var JwtToken = localStorage.getItem('token')
        console.log("Axios Delete ",Id)
        console.log("Axios Delete JwtToken ",JwtToken)
        return axios.delete(`https://localhost:44338/api/Notes/${Id}`,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }
    ArchiveNotesService(Id)
    {
        var JwtToken = localStorage.getItem('token')
        console.log("Axios Archive ",Id)
        console.log("Axios Archive JwtToken ",JwtToken)

        return axios.post("https://localhost:44338/api/Notes/"+Id+"/Archive",null,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }

    TrashNotesService(Id)
    {
        var JwtToken = localStorage.getItem('token')
        console.log("Axios Trash ",Id)
        console.log("Axios Trash JwtToken ",JwtToken)
        return axios.post("https://localhost:44338/api/Notes/"+Id+"/Trash",null,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }
}