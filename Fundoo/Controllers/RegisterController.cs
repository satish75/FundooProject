// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterController.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// ----------------------------------------------------------------------------------------------------
namespace Fundoo.Controllers
{
    using StackExchange.Redis;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using BussinessLayer.Interface;
    using Common.Models;
    using Microsoft.EntityFrameworkCore.Storage;
    using System;
    using Nancy.Authentication.Forms;
    using Nancy.Session;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Cors;

    /// <summary>
    /// This is Controller class which is used to specifies API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// 
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
     [AllowAnonymous]
  
    public class RegisterController : ControllerBase
    {
        private readonly IBussinessRegister _bussinessRegister;
        public RegisterController(IBussinessRegister bussinessRegister)
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
            var result = await _bussinessRegister.Register(details);
            return result;
        }

        /// <summary>
        /// Logins the specified login model.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
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
        /*  public async Task<string> Login(LoginModel loginModel)
          {
              var result = await _bussinessRegister.Login(loginModel);
              return result;
          }*/

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("forgetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword(ForgotPasswordModel model)
        {
            var result = await this._bussinessRegister.ForgotPassword(model);
            if (result != null)
            {
                return this.Ok(new { result });
            }
            else
            {
                return this.Unauthorized();
            }
        }

         [HttpPost]
        [Route("resetPassword")]
        [AllowAnonymous]
        public async Task<bool> ResetPassword(ResetPasswordModel model)
        {
            var result = await this._bussinessRegister.ResetPassword(model);
            return result;
        }


        [HttpPost]
        [Route("Image")]
        [AllowAnonymous]
        public IActionResult UploadImage(string userid, IFormFile file)
        {
            var urlOfImage = _bussinessRegister.UploadImage(userid, file);
            // return urlOfImage;
            return Ok(new { urlOfImage });
        }
    }
}