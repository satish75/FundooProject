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

    GetNotesTrash()
    {
        console.log("GetNotesService");
       
        var JwtToken = localStorage.getItem('token')
       console.log("This is get notes service", JwtToken);
        return axios.get(`https://localhost:44338/api/Notes/GetAllTrash`, {
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }
    GetNotesArchive()
    {
        console.log("GetNotesService");
       
        var JwtToken = localStorage.getItem('token')
       console.log("This is get notes service", JwtToken);
        return axios.get(`https://localhost:44338/api/Notes/GetAllArchive`, {
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }

    ColorService(data)
    {
        var jwtToken = localStorage.getItem('token')
        console.log("Axios  Id  ",data.Id)
        console.log("Axios Color   ",data.color)

        console.log("Axios Trash JwtToken ",jwtToken)
        return axios.put("https://localhost:44338/api/Notes/"+data.Id+"/"+data.color+"/color",null,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${jwtToken}`
            }})
    }

    CollabarateService(data)
    {
        var JwtToken = localStorage.getItem('token')
        console.log("Axios collabarotor Id ",data.Id)
        console.log("Axios collabarotor Lis ",data.list)

        console.log("Axios Trash JwtToken ",JwtToken)
        return axios.post("https://localhost:44338/api/Notes/"+data.list+"/"+data.Id+"/Collaborate",null,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }

    GetLabelService()
    {
        console.log("user label service");
       
        var JwtToken = localStorage.getItem('token')
       console.log("This is get notes service", JwtToken);
        return axios.get(`https://localhost:44338/api/Label`, {
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }


    AddLabelWithoutNoteService(data)
    {
        var JwtToken = localStorage.getItem('token')
        console.log("Axios EditLabel data ",data.EditLabel)
       

        console.log("Axios Trash JwtToken ",JwtToken)
        return axios.post("https://localhost:44338/api/Label/"+data.EditLabel+"/Add",null,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }
    ArchiveIconService(id)
    {
        var JwtToken = localStorage.getItem('token')
        console.log("Axios Label note id  ",id)
       

        console.log("Axios Trash JwtToken ",JwtToken)
        return axios.post("https://localhost:44338/api/Notes/"+id+"/Archive",null,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }

    GetEmailService()
    {
        console.log("user label service");
       
        var JwtToken = localStorage.getItem('token')
       console.log("This is get notes service", JwtToken);
        return axios.get(`https://localhost:44338/api/Label`, {
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }

    EditLabelService(data)
    {
        var JwtToken = localStorage.getItem('token')
        console.log("Axios Label label id  ",data.Id)
        console.log("Axios Label label name  ",data.name)

       

        console.log("Axios Label JwtToken ",JwtToken)
        return axios.post("https://localhost:44338/api/Label/"+data.Id+"/"+data.name+"/edit",data,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }

    DeleteLabelService(Id)
    {
        var JwtToken = localStorage.getItem('token')
        console.log("Axios Delete ",Id)
        console.log("Axios Delete JwtToken ",JwtToken)
        return axios.delete(`https://localhost:44338/api/Label/${Id}`,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }
    UpdateNotesService(data)
    {
        var JwtToken = localStorage.getItem('token')
        console.log("Axios title update ",data.title)
        console.log("Axios description  update  ",data.description)
        console.log("Axios note Reminder  update ",data.reminder)
        console.log("Axios User Id  update  ",data.userId)
       

        console.log("Axios Label JwtToken ",JwtToken)
        return axios.put("https://localhost:44338/api/Notes/"+data.noteId,data,{
            headers:{
                'Content-Type': 'application/json',
                'Accept': '*',
                Authorization: `bearer ${JwtToken}`
            }})
    }


}