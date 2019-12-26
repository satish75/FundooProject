// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesController.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace Fundoo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BussinessLayer.Interface;
    using Common.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [EnableCors("CorsPolicy")]
    public class NotesController : ControllerBase
    {
        private readonly IBussinessNotes _bussinessRegister;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/> class.
        /// </summary>
        /// <param name="bussinessRegister">The bussiness register.</param>
        public NotesController(IBussinessNotes bussinessRegister)
        {
            _bussinessRegister = bussinessRegister;
        }

        /// <summary>
        /// Adds the user detail.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        [HttpPost]
        //  [Route("Notes")]
       
     
        public async Task<IActionResult> CreateNotes(NotesModel details)
        {
            var id = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = await _bussinessRegister.CreateNotes(details,id);    
            if(results)
            {
                return Ok(new { results = "Added Successfully" });
            }
            else
            {
                return Ok(new { results = "Failed to add" });
            }
            
        }

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        [HttpGet]
       
        public IActionResult GetNotes()
        {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results =  _bussinessRegister.GetNotes(userId);
            if (results != null)
            {
                return Ok(new {result= results });
            }
            else
            {
                return Ok(new { results = "failed to get" });
            }
           
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut]
       
      
        public async Task<IActionResult> UpdateNotes(NotesModel details,int id)
        {
              var results = await _bussinessRegister.UpdateNotes(details,id);
            if(results)
            {
                return Ok(new { results ="Successfully Updated" });
            }
            else
            {
                return Ok(new { results="Failed to Update " });
            }
           
        }

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
      // [AllowAnonymous]
        public async Task<IActionResult> DeleteNotes(List<int> id)
        {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = await _bussinessRegister.DeleteNotes(id, userId);
            if (results)
                return Ok(new { success=true , message = "deleted " });
            else
                return Ok(new { success = false , message = "failed to delete" });
           
        }

        [HttpPost]
        [Route("{id}/Trash")]
        //[AllowAnonymous]
        public async Task<IActionResult> Trash(int id)
        {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = await _bussinessRegister.Trash(id,userId);
            if (results)
            {
                return Ok(new { results = "Successfully Added To Trash" });
            }
            else
            {
                return Ok(new { results = "Failed to Add " });
            } 
        }

        [HttpPost]
        [Route("Restored")]
        //[AllowAnonymous]
        public async Task<IActionResult> TrashRestore(int id)
        {
            var results = await _bussinessRegister.TrashRestore(id);
            if (results)
            {
                return Ok(new { results = "Successfully Restored from  Trash" });
            }
            else
            {
                return Ok(new { results = "Failed to remove " });
            }
        }

        [HttpDelete]
        //[AllowAnonymous]
         [Route("forever")]
        public async Task<IActionResult> DeleteForever(List<int> id,string UserId)
        {
            var results = await _bussinessRegister.DeleteForever(id, UserId);
            if(results)
            return Ok(new { results="deleted permanently" });
            else
                return Ok(new { results = "failed to delete" });
        }

        [HttpPost]
        [Route("{id}/Archive")]
       
        public async Task<IActionResult> Archive(int id)
        {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = await _bussinessRegister.Archive(id, userId);
            if (results)
            {
                return Ok(new { status = true,message = " Successfull ",data="" });
            }
            else
            {
                return Ok(new { status = false, message = " failed ", data = "" });
            }
        }
  

        [HttpPost]
        [Route("IsPin")]
        //[AllowAnonymous]
        public async Task<IActionResult> Pin(int id)
        {
            var results = await _bussinessRegister.Pin(id);
            if (results)
            {
                return Ok(new { results = " Success " });
            }
            else
            {
                return Ok(new { results = "Failed  " });
            }
        }
       
        [HttpPost]
        [Route("Image")]
        //[AllowAnonymous]
        public IActionResult UploadImage(string userid, int id, IFormFile file)
        {
            var urlOfImage =  _bussinessRegister.UploadImage(userid, id, file);
          
            return Ok(new {url= urlOfImage });
        }

        [HttpPost]
        [Route("Collaborate")]
        //[AllowAnonymous]
        public async Task<IActionResult> Collaborate(IList<string> id, int noteId)
        {
            try
            {
                var results = await _bussinessRegister.Collaborate(id, noteId);
                if (results)
                {
                    return Ok(new { results = "Successfully Added To Trash" });
                }
                else
                {
                    return Ok(new { results = "Failed to Add " });
                }
            }
            catch(Exception e)
            {
                return Ok(new { results = new Exception(e.Message.ToString()) });
            }
            
        }

        [HttpPost]
        [Route("Search")]
        //[AllowAnonymous]
        public async Task<IActionResult> Search(string word, string Id)
        {
            try
            {
                var results = await Search(word, Id);
                if (results != null)
                {

                    return Ok(new { results = "successfull " });
                }
                else
                {
                    return Ok(new { results = "Failed to Search " });
                }
            }
            catch (Exception e)
            {
                return Ok(new { results = new Exception(e.Message.ToString()) });
            }

        }

        [HttpGet]
        [Route("GetAllTrash")]
        public IActionResult GetAllTrash()
        {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = _bussinessRegister.GetAllTrash(userId);
            if (results != null)
            {
                return Ok(new {status=true,message="successfull", data = results });
            }
            else
            {
                return Ok(new {status=false,message="failed", data = "" });
            }

        }
        [HttpGet]
        [Route("GetAllArchive")]
        public IActionResult GetAllArchive()
        {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = _bussinessRegister.GetAllArchive(userId);
            if (results != null)
            {
                return Ok(new { status = true, message = "successfull", data = results });
            }
            else
            {
                return Ok(new { status = false, message = "failed", data = "" });
            }

        }
        [HttpPut]
        [Route("{id}/{color}/color")]
        //[AllowAnonymous]
        public async Task<IActionResult> ColorService(int id,string color)
        {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            ColorModel colorObj = new ColorModel();
            colorObj.noteId = id;
            colorObj.userId = userId;
            colorObj.color = color;
            var results =   _bussinessRegister.ColorService(colorObj);
            if (results)
            {
                return Ok(new { status=true,message="successfull" , data = "" });
            }
            else
            {
                return Ok(new { results = "Failed to change " });
            }
        }
    }
}