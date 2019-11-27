
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IAdminSignUpRepository
    {
        Task<bool> AdminRegister(RegistrationModel user);
        Task<string> Login(LoginModel loginModel);
         Dictionary<string, int> Statistic();
      ///  IList<ApplicationModel> UserList();
        IList<RegistrationModel> GetUsers(int page, int pageSize);
    }
}
