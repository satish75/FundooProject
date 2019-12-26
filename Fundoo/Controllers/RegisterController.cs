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
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.Extensions.Configuration;
    using System.IdentityModel.Tokens.Jwt;


    /// <summary>
    /// This is Controller class which is used to specifies API
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// 
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
   
  
    public class RegisterController : ControllerBase
    {
        private readonly IBussinessRegister _bussinessRegister;
        private readonly IConfiguration configuration;
        public RegisterController(IBussinessRegister bussinessRegister, IConfiguration configuration)
        {
            _bussinessRegister = bussinessRegister;
            this.configuration = configuration;
        }

        /// <summary>
        /// Adds the user detail.
        /// </summary>
        /// <param name="details">The details.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
         [AllowAnonymous]
        public async Task<IActionResult> AddUserDetails(RegistrationModel details)
        {
            var result = await _bussinessRegister.Register(details);
            if(result)
            {
                return this.Ok(new { result = "successfully added" });
            }
            else
            {
                return this.Ok(new { result = "failed to add" });
            }
          
           
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
            

            var result = await this._bussinessRegister.Login(login);
            if (result != null)
            {
                var token = TokenGeneration(result);         
                return this.Ok(new { success = true, message = "LogIn Successfull", token, result });
            }
            else
            {
              
                return this.Ok(new { results = "Login Failed" });
               
            }

        }
       

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("forgetPassword")]
      
        public async Task<IActionResult> ForgetPassword(ForgotPasswordModel model)
        {
            var result = await this._bussinessRegister.ForgotPassword(model);
            if (result != null)
            {
                return this.Ok(new { result="successfull" });
            }
            else
            {
                return this.Ok(new {results="Unautharize" });
            }
        }

         [HttpPost]
        [Route("resetPassword")]
       
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            var result = await this._bussinessRegister.ResetPassword(model);

            if (result)
            {
             
                return Ok(new { results = " Success " });
            }
            else
            {
                return this.Ok(new { results = "Unautharize" });
            }
           
        }


        [HttpPost]
        [Route("Image")]
     
        public IActionResult UploadImage(string userid, IFormFile file)
        {
            var urlOfImage = _bussinessRegister.UploadImage(userid, file);
            // return urlOfImage;
            return Ok(new { url = urlOfImage });
        }

        [HttpGet]
        public string TokenGeneration(RegistrationModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));

            //// here using securitykey and algorithm(security) the creadintails is generate(SigningCredentials present in Token)
            var creadintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
               new Claim("UserName",model.UserName),
               new Claim("UserId", (model.Id)),
               new Claim("Email", (model.Email)),
                };

            var token = new JwtSecurityToken("Security token", "https://Test.com",
                claims,
                DateTime.UtcNow,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creadintials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}