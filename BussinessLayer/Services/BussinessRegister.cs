﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BussinessRegister.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// ----------------------------------------------------------------------------------------------------
namespace BussinessLayer.Services
{
    using ServiceStack.Redis;
    using BussinessLayer.Interface;
    using Common.Models;
    using RepositoryLayer.Interface;
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class BussinessRegister : IBussinessRegister
    {
        /// <summary>
        /// here create the Repository references
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// This is Constructor
        /// </summary>
        /// <param name="repository"></param>
        public BussinessRegister(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// this method used to register the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> Register(RegistrationModel user)
        {
            try
            {
                if (user != null)
                {
                    return await _repository.Register(user);
                }
                else
                {
                    throw new Exception("User is empty");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// this method used for login the user and authenticate user.
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public async Task<RegistrationModel> Login(LoginModel loginModel)
        {

            try
            {
               
                ///if loginModel is not null it will return result else throw the exception 
                if (!loginModel.Equals(null))
                {
                    var result = await this._repository.Login(loginModel);
                   

                    return result;
                }
                else
                {
                    throw new Exception("Unable to log in");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="forgotPasswordModel">The forgot password model.</param>
        /// <returns></returns>
        public async Task<string> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            var result = await this._repository.ForgotPassword(forgotPasswordModel);
            return result.ToString();
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="resetPasswordModel">The reset password model.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        /// <exception cref="Exception">loginModel is empty</exception>
        public async Task<bool> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            try
            {
                if (resetPasswordModel != null)
                {
                    return await _repository.ResetPassword(resetPasswordModel);
                }
                else
                {
                    throw new Exception("loginModel is empty");
                }
            }
            catch (Exception exception)
            {
                throw exception ;
            }
        }

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Image is not uploaded</exception>
        public string UploadImage(string userid, IFormFile file)
        {
            try
            {
                ImageCloudinary cloudinary = new ImageCloudinary();
                var url = cloudinary.ImgaeUrl(file);
                if (userid != null)
                {
                    return _repository.UploadImage(url, userid, file); 
                }
                else
                {
                    throw new Exception("Image is not uploaded");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}