using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BussinessLayer.Interface;
using Microsoft.Extensions.Configuration;
using Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Context;

namespace Fundoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminSignUpBussiness _bussinessRegister;

      
        public AdminController(IAdminSignUpBussiness bussinessRegister)
        {
            _bussinessRegister = bussinessRegister;
           
        }

        /// <summary>
        /// Adds the user detail.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<bool> AddUserDetails(RegistrationModel details)
        {
            var result = await _bussinessRegister.AdminRegister(details);
            return result;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var token = await this._bussinessRegister.Login(login);
            if (token != null)
            {
                ////subsrtring method to separate the token and login time
                var lastlogin = token.Substring(token.IndexOf('+') + 1);
                token = token.Substring(0, token.IndexOf('+'));
                var status = "Login Successfull";
                ////returning the token and last login time                
                return this.Ok(new { token, lastlogin, status });
            }
            else
            {
                return this.Unauthorized();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public Dictionary<string, int> Statistic()
        {
            return _bussinessRegister.Statistic();         
        }

        //[HttpGet]
        //[Route("List")]
        //[AllowAnonymous]
        //public IList<ApplicationModel> UserList()
        //{
        //    var results = _bussinessRegister.GetUsers();
        //    if (results != null)
        //        return results;
        //    else
        //        return null;
        //}

        [HttpGet]
        [Route("get")]
        [AllowAnonymous]
        public IList<RegistrationModel> GetUsers(int pageNumber, int pageSize)
        {

            var results = _bussinessRegister.GetUsers(pageNumber, pageSize);
            return results;
        }

     
    }
}