
using Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class AdminSignUpRepository : IAdminSignUpRepository
    {

        /// <summary>
        /// User Manager
        /// </summary>
        private readonly UserManager<ApplicationModel> _userManager;
        private readonly ContextData _contextData;
       // private readonly ContextData _Data;
        private readonly DbSet<RegistrationModel> _Data;
        private readonly IConfiguration _configuration;
  

        /// <summary>
        /// Create the parameterized Constructor of class and pass the UserManager
        /// </summary>
        /// <param name="userManager"></param>
        public AdminSignUpRepository(UserManager<ApplicationModel> userManager, ContextData contextData, IConfiguration configuration)
        {
            _userManager = userManager;
            _contextData = contextData;
            _configuration = configuration;
        }
       
        public async Task<bool> AdminRegister(RegistrationModel user)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
                SqlCommand sqlCommand = new SqlCommand("SpInsert", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                ////  sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
                sqlCommand.Parameters.AddWithValue("@Mobile", user.Mobile);
                sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                sqlCommand.Parameters.AddWithValue("@UserName", user.UserName);
                sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                sqlCommand.Parameters.AddWithValue("@ProfileImage", user.ProfileImage);
                sqlCommand.Parameters.AddWithValue("@UserType", "Admin");
                sqlCommand.Parameters.AddWithValue("@ServiceType", "NULL");
                sqlConnection.Open();
                var respone = await sqlCommand.ExecuteNonQueryAsync();
                if (respone != 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        RegistrationModel userTypeData;
        public async Task<string> Login(LoginModel loginModel)
        {
         
            SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            //// it confirms that user is avaiable in database or not
            ///var user = await _userManager.FindByNameAsync(loginModel.UserName);


            SqlCommand sqlCommand = new SqlCommand("SpAdminGet", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserName", loginModel.UserName);
            sqlCommand.Parameters.AddWithValue("@Password", loginModel.Password);
            sqlConnection.Open();


            SqlDataReader sdr = sqlCommand.ExecuteReader();
            // RegistrationModel user = new RegistrationModel();

            while (sdr.Read())
            {
                userTypeData = new RegistrationModel();
                userTypeData.UserName = sdr["UserName"].ToString();
                userTypeData.Password = sdr["Password"].ToString();
            }
            sdr.Close();

            //// check the username and password is matched in database or not
            if (userTypeData != null)
            {
                string key = "EF4ABEAB56153D93D0E97048FC50215C0264CFF";

                ////Here generate encrypted key and result store in security key
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                //// here using securitykey and algorithm(security) the creadintails is generate(SigningCredentials present in Token)
                var creadintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[] {
               new Claim("UserName",userTypeData.UserName),
                };

                var token = new JwtSecurityToken("Security token", "https://Test.com",
                    claims,
                    DateTime.UtcNow,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creadintials);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return "Invalid User";
            }

        }

        public Dictionary<string,int> Statistic()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            //var results = from users in _contextData.User
            //            select users;

            SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);           
            SqlCommand sqlCommand = new SqlCommand("SpStatistic", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            SqlDataReader sdr = sqlCommand.ExecuteReader();


            int advance = 0, basic = 0;
            foreach (var user in sdr)
            {
                if (sdr["ServiceType"].ToString() == "advance")
                {
                    advance++;
                }
                else if (sdr["ServiceType"].ToString() == "basic")
                {
                    basic++;
                }
            }
            dictionary.Add("Advance", advance);
            dictionary.Add("Basic", basic);
            return dictionary;

        }

        public IList<RegistrationModel> GetUsers(int pageNumber,int pageSize)
        {

            // Return List of Customer  


            IList<RegistrationModel> registrationModels = new List<RegistrationModel>();

            SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            SqlCommand sqlCommand = new SqlCommand("SpStatistic", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            SqlDataReader sdreader = sqlCommand.ExecuteReader();          
            while (sdreader.Read())
            {
                RegistrationModel userList = new RegistrationModel();
                userList.UserName = sdreader["UserName"].ToString();
                userList.Password = sdreader["Password"].ToString();
                userList.Id = Convert.ToInt32(sdreader["Id"]);
                userList.FirstName = sdreader["FirstName"].ToString();
                userList.LastName = sdreader["LastName"].ToString();
                userList.Email = sdreader["Email"].ToString();
                userList.Mobile = sdreader["Mobile"].ToString();
                userList.ProfileImage = sdreader["ProfileImage"].ToString();
                userList.ServiceType = sdreader["ServiceType"].ToString();
                userList.UserName = sdreader["UserName"].ToString();
                registrationModels.Add(userList);
            }
            sdreader.Close();

            //var source = (from customer in registrationModels
            //              select customer);
            // Get's No of Rows Count   
            int count = registrationModels.Count();

            // Parameter is passed from Query string if it is null then it default Value will be pageNumber:1  
            int CurrentPage = pageNumber;

            // Parameter is passed from Query string if it is null then it default Value will be pageSize:20  
            int PageSize = pageSize;

            // Display TotalCount to Records to User  
            int TotalCount = count;

            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            // Returns List of Customer after applying Paging  
            if (CurrentPage == 0)
            {
                CurrentPage++;
                var items = registrationModels.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            }
            //var source1 = (from customer in _contextData.User
            //               select customer);
            int numberOfObjectsPerPage = pageSize;
            var queryResultPage = registrationModels
              .Skip(numberOfObjectsPerPage * pageNumber)
              .Take(numberOfObjectsPerPage);

            return queryResultPage.ToList();
        }
    }
}
