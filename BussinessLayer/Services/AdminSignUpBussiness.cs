using BussinessLayer.Interface;

using Common.Models;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interface;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class AdminSignUpBussiness : IAdminSignUpBussiness
    {

        private readonly IAdminSignUpRepository _repository;

        /// <summary>
        /// This is Constructor
        /// </summary>
        /// <param name="repository"></param>
        public AdminSignUpBussiness(IAdminSignUpRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AdminRegister(RegistrationModel user)
        {
            try
            {
                if (user != null)
                {
                    return await _repository.AdminRegister(user);
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

        public IList<RegistrationModel> GetUsers(int page, int pageSize)
        {
            return _repository.GetUsers(page, pageSize);
        }

        public async Task<string> Login(LoginModel loginModel)
        {

            try
            {
                var lastLoginTime = "";
                ///if loginModel is not null it will return result else throw the exception 
                if (!loginModel.Equals(null))
                {
                    var result = await this._repository.Login(loginModel);
                    if (result != null)
                    {
                        ///storing the current time in the variable
                        var newLoginTime = DateTime.Now.ToString();

                        /// this using stored the username of login and its time
                        using (var redis = new RedisClient())
                        {
                            ///getting the logintime from redis
                            if (redis.Get("lastLogin" + loginModel.UserName) == null)
                            {
                                ///setting the login time to the redis
                                redis.Set("lastLogin" + loginModel.UserName, newLoginTime);
                            }
                            else
                            {
                                ///changing the datetime formate to the string formate
                                string utfString = System.Text.Encoding.UTF8.GetString(redis.Get("lastLogin" + loginModel.UserName));
                                redis.Set("lastLogin" + loginModel.UserName, newLoginTime);
                                lastLoginTime = "+" + utfString;
                            }
                        }
                    }

                    return result + lastLoginTime;
                }
                else
                {
                    throw new Exception("login model is null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Dictionary<string, int> Statistic()
        {
          return _repository.Statistic();
        }

        //public IList<ApplicationModel> UserList()
        //{
        //    return _repository.UserList();
        //}
    }
}
