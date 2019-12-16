// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBussinessRegister.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// ----------------------------------------------------------------------------------------------------
namespace BussinessLayer.Interface
{
    using Common.Models;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    public interface IBussinessRegister
    {
        /// <summary>
        /// Adds the user details.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<bool> Register(RegistrationModel user);

        /// <summary>
        /// Logins the specified login model.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        Task<string> Login(LoginModel loginModel);

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        Task<string> ForgotPassword(ForgotPasswordModel loginModel);

        Task<bool> ResetPassword(ResetPasswordModel resetPasswordModel);

        string UploadImage(string userid, IFormFile file);
    }
}
