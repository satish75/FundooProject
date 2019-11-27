
using Common.Models;
using Common.MSMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
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
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace RepositoryLayer.Services
{
    /// <summary>
    /// RegistrationRL
    /// </summary>
    public class RegisterRepository : IRepository
    {
        /// <summary>
        /// User Manager
        /// </summary>
        private readonly UserManager<ApplicationModel> _userManager;
        private readonly ContextData _contextData;
        private readonly IConfiguration _configuration ;
       // RegistrationModel userType;

        /// <summary>
        /// Create the parameterized Constructor of class and pass the UserManager
        /// </summary>
        /// <param name="userManager"></param>
        public RegisterRepository(UserManager<ApplicationModel> userManager, ContextData contextData,IConfiguration configuration)
        {
           _userManager = userManager;
            _contextData = contextData;
            _configuration = configuration;
        }
     
        /// <summary>
        /// AddUser Details 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> Register(RegistrationModel user)
        {
         
            //// Create the instance of ApplicationUser and store the details
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
                sqlCommand.Parameters.AddWithValue("@UserType", user.UserType);
                sqlCommand.Parameters.AddWithValue("@ServiceType", user.ServiceType);
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

        /// <summary>
        /// Logins the specified login model.
        /// </summary>
        /// <param name="loginModel">The login model.</param>
        /// <returns></returns>
        /// 
        RegistrationModel userTypeData;
        public async Task<string> Login(LoginModel loginModel)
        {
            SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            //// it confirms that user is avaiable in database or not
            ///var user = await _userManager.FindByNameAsync(loginModel.UserName);
           

            SqlCommand sqlCommand = new SqlCommand("SpGetUserName", sqlConnection);
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

        /// <summary>
        /// Forgots the password.
        /// </summary>
        /// <param name="forgotPasswordModel">The forgot password model.</param>
        /// <returns></returns>
        public async Task<string> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
         {
            try
            {
                ///  var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email);
                ///  
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
                //// it confirms that user is avaiable in database or not
                ///var user = await _userManager.FindByNameAsync(loginModel.UserName);


                SqlCommand sqlCommand = new SqlCommand("SpGetUserEmail", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", forgotPasswordModel.Email);             
                sqlConnection.Open();

                SqlDataReader sdr = sqlCommand.ExecuteReader();
                 RegistrationModel user = new RegistrationModel();

                while (sdr.Read())
                {
                    user = new RegistrationModel();
                    user.Email = sdr["Email"].ToString();                  
                }
                sdr.Close();

                if (user != null)
                {
                    ////msmq object
                    MsmqTokenSender msmq = new MsmqTokenSender();


                    ////it creates the SecurityTokenDescriptor
                    var tokenDescripter = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("Email", user.Email.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),

                    };

                    var tokenHandler = new JwtSecurityTokenHandler();

                    ////it creates the security token
                    var securityToken = tokenHandler.CreateToken(tokenDescripter);

                    ////it writes security token to the token variable.
                    var token = tokenHandler.WriteToken(securityToken);
                    msmq.SendTokenQueue(forgotPasswordModel.Email, token);
                    return token;
                }
                else
                {
                    return "Invalid user";
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message.ToString()); 
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="resetPasswordModel">The reset password model.</param>
        /// <param name="tokenString">The token string.</param>
        /// <returns></returns>
        public async Task<bool> ResetPassword(ResetPasswordModel resetPasswordModel, string tokenString)
        {
            //  var jwtEncodedString = tokenString.Substring(7); // trim 'Bearer ' from the start since its just a prefix for the token string

            var token = new JwtSecurityToken(jwtEncodedString: tokenString);
            var Email = (token.Claims.First(c => c.Type == "Email").Value);

            /// To get Email From database -------------------------------
            /// 
            ///  
            SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            //// it confirms that user is avaiable in database or not
            ///var user = await _userManager.FindByNameAsync(loginModel.UserName);


            SqlCommand sqlCommand = new SqlCommand("SpReset", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Email", Email);        
            sqlCommand.Parameters.AddWithValue("@Password", resetPasswordModel.Password);          
            sqlConnection.Open();
            if(Email != null)
            {
                var respone = await sqlCommand.ExecuteNonQueryAsync();
                return true;
            }
            else
            {
                return false;
            }
  
        }

        public string UploadImage(string url, string userid, IFormFile file)
        {
            var image = (from notes in _contextData.User
                         where notes.Id == userid
                         select notes).FirstOrDefault();

            image.ProfileImage = url;
            var result = _contextData.SaveChanges();


            if (result > 0)
            {
                return url;
            }
            else
            {
                return "Image not uploaded";
            }
        }
    }
}
