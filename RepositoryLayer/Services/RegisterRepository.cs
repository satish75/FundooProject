
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
                sqlCommand.Parameters.AddWithValue("@ServiceType", user.ServiceType);
                sqlCommand.Parameters.AddWithValue("@Email", user.UserName + "@gmail.com");
             sqlCommand.Parameters.AddWithValue("@UserName", user.UserName);
                sqlCommand.Parameters.AddWithValue("@Password", user.Password);
               
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
        public async Task<RegistrationModel> Login(LoginModel loginModel)
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
                userTypeData.Email = sdr["Email"].ToString();
                userTypeData.Id = sdr["UserId"].ToString();


            }
            sdr.Close();

            return userTypeData;

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
                SqlConnection con = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);

                SqlCommand sqlCommand = new SqlCommand("SpGetUserEmail", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Email", forgotPasswordModel.Email);
                con.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                ForgotPasswordModel model = null;
                while (dataReader.Read())
                {
                    model = new ForgotPasswordModel();
                    model.Email = dataReader["Email"].ToString();
                }

                dataReader.Close();

                if (model != null)
                {
                    ////here we create object of MsmqTokenSender which is present in Common-Layer
                    MsmqTokenSender msmq = new MsmqTokenSender();
                    string key = "This is my SecretKey which is used for security purpose";

                    ////Here generate encrypted key and result store in security key
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                    //// here using securitykey and algorithm(security) the creadintails is generate(SigningCredentials present in Token)
                    var creadintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {
                    new Claim("Email", model.Email),
                };

                    var token = new JwtSecurityToken("Security token", "https://Test.com",
                        claims,
                        DateTime.UtcNow,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: creadintials);

                    var NewToken = new JwtSecurityTokenHandler().WriteToken(token);

                    //// Send the email and password to Method in MsmqTokenSender
                    msmq.SendTokenQueue(forgotPasswordModel.Email, NewToken.ToString());
                    return NewToken;
                }
                else
                {
                    return "Invalid user";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="resetPasswordModel">The reset password model.</param>
        /// <param name="tokenString">The token string.</param>
        /// <returns></returns>
        public async Task<bool> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            //  var jwtEncodedString = tokenString.Substring(7); // trim 'Bearer ' from the start since its just a prefix for the token string

            var token = new JwtSecurityToken(jwtEncodedString: resetPasswordModel.token);
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
            ImageCloudinary cloudinary = new ImageCloudinary();
            var urlImage = cloudinary.ImgaeUrl(file);
            SqlConnection con = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            SqlCommand sqlCommand = new SqlCommand("SpAddProfileUser", con);
           
            sqlCommand.Parameters.AddWithValue("@UserId", userid);
            sqlCommand.Parameters.AddWithValue("@Image", url);
            con.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var result = sqlCommand.ExecuteNonQuery();

            if (result != 0)
            {
                return urlImage;
            }
            else
            {
                return "Image not uploaded";
            }
        }
    }
}
