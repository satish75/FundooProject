// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelController.cs" company="Bridgelabz">
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
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class LabelController : ControllerBase
    {
        private readonly IBussinessLabel _bussinessLabel;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController"/> class.
        /// </summary>
        /// <param name="bussinessLabel">The bussiness label.</param>
        public LabelController(IBussinessLabel bussinessLabel)
        {
            _bussinessLabel = bussinessLabel;
        }

        /// <summary>
        /// Adds the specified details.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        [HttpPost]
        // [Route("Add")]
    
        public async Task<IActionResult> Add(IList<string> label, int noteId, string userId)
        {
            var results = await _bussinessLabel.Add(label, noteId, userId);
            if(results)
            {
                return Ok(new { results = "Added Successfully" });
            }
            else
            {
                return Ok(new { results = " Failed " });
            }
        }

        [HttpPost]
         [Route("{label}/Add")]

        public async Task<IActionResult> AddLabel(string label)
        {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = await _bussinessLabel.AddLabel(label, userId);
            if (results != null)
            {
                return Ok(new {status =true, message = "Added Successfully" ,data=results });
            }
            else
            {
                return Ok(new {status=false, message = " Failed " ,data=""});
            }
        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        /// 
        [HttpGet]
       /// [Route("")]
    
        public IActionResult GetLabel()
      {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = _bussinessLabel.GetLabel(userId);
            if(results !=null)
            return Ok(new { status=true,message="successfull",data=results});
            else
                return Ok(new { status = false, message = "failed", data = results });

        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPost]
         [Route("{id}/{labelData}/edit")]
        public async Task<IActionResult> UpdateLabel(int id,string labelData)
        {
            string label = labelData;
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = await _bussinessLabel.UpdateLabel(id,label);
            if(results)
            {
                return Ok(new { results = "Successfully Updated" });
            }
            else
            {
                return Ok(new { results = "Failed" });
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
        public async Task<IActionResult> DeleteLabel(int id)
        {
            var userId = HttpContext.User.Claims.First(c => c.Type == "UserId").Value;
            var results = await _bussinessLabel.DeleteLabel(id);
            if(results.Equals("Deleted"))
            return Ok(new { results ="delete successfully" });
            else
                return Ok(new { results = "failed" });
        }
    }
}