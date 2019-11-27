// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAdminSignUpBussiness.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace BussinessLayer.Interface
{
    using Common.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAdminSignUpBussiness
    {
        /// <summary> 
        /// Admins the register.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<bool> AdminRegister(RegistrationModel user);
        Task<string> Login(LoginModel loginModel);
        Dictionary<string, int> Statistic();

       /// IList<ApplicationModel> UserList();

        IList<RegistrationModel> GetUsers(int page, int pageSize);
    }
} 
