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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> CreateNotes(NotesModel details)
        {
            var results = await _bussinessRegister.CreateNotes(details);    
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
       [Route("{id}")]
        [AllowAnonymous]
        public IList<NotesModel> GetNotes(string id)
        {
            var results = _bussinessRegister.GetNotes(id);
            return results;
        }

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut]
        [AllowAnonymous]
      
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
       // [Route("Notes")]
       [AllowAnonymous]
        public async Task<IActionResult> DeleteNotes(List<int> id,string UserId)
        {
            var results = await _bussinessRegister.DeleteNotes(id, UserId);
            return Ok(new {results});
        }

        [HttpPost]
        [Route("Trash")]
        [AllowAnonymous]
        public async Task<IActionResult> Trash(int id)
        {
            var results = await _bussinessRegister.Trash(id);
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
        [AllowAnonymous]
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
        [AllowAnonymous]
         [Route("forever")]
        public async Task<IActionResult> DeleteForever(List<int> id,string UserId)
        {
            var results = await _bussinessRegister.DeleteForever(id, UserId);
            return Ok(new { results });
        }

        [HttpPost]
        [Route("IsArchive")]
        [AllowAnonymous]
        public async Task<IActionResult> Archive(int id)
        {
            var results = await _bussinessRegister.Archive(id);
            if (results)
            {
                return Ok(new { results = " Success " });
            }
            else
            {
                return Ok(new { results = "Failed to Add " });
            }
        }
  

        [HttpPost]
        [Route("IsPin")]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public IActionResult UploadImage(string userid, int id, IFormFile file)
        {
            var urlOfImage =  _bussinessRegister.UploadImage(userid, id, file);
            // return urlOfImage;
            return Ok(new { urlOfImage });
        }

        [HttpPost]
        [Route("Collaborate")]
        [AllowAnonymous]
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
                throw new Exception(e.Message.ToString());
            }
            
        }

        [HttpPost]
        [Route("Search")]
        [AllowAnonymous]
        public IList<NotesModel> Search(string word, string Id)
        {
            try
            {
                var results = _bussinessRegister.Search(word, Id);
                if (results != null)
                {
                    return  results ;
                }
                else
                {
                    return  results ;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }

        }
    }
}