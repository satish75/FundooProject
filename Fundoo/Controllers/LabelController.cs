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
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    [Route("api/[controller]")]
    [ApiController]
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
        [AllowAnonymous]
        public async Task<IActionResult> Add(LabelModel details)
        {
            var results = await _bussinessLabel.Add(details);
            if(results)
            {
                return Ok(new { results = "Added Successfully" });
            }
            else
            {
                return Ok(new { results = " Failed " });
            }
        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("{id}")]
     //   [AllowAnonymous]
        public IList<LabelModel> GetLabel(string id)
        {
            var results = _bussinessLabel.GetLabel(id);

            return results;
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut]
        //[Route("update")]
        public async Task<IActionResult> UpdateLabel(LabelModel details, int id)
        {
            var results = await _bussinessLabel.UpdateLabel(details, id);
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
       // [Route("delete")]
        public async Task<IActionResult> DeleteLabel(int id)
        {
            var results = await _bussinessLabel.DeleteLabel(id);
            return Ok(new { results });
        }
    }
}