// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryLabel.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace RepositoryLayer.Services
{
    using Common.Models;
    using Microsoft.Extensions.Configuration;
    using RepositoryLayer.Context;
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// this class implemented from IRepository Label interface
    /// </summary>
    /// <seealso cref="RepositoryLayer.Interface.IRepositoryLabel" />
    public class RepositoryLabel : IRepositoryLabel
    {

        private readonly ContextData _contextData;
        private readonly IConfiguration _configuration;
        //private IConfiguration _configuration;

        /// <summary>
        /// Create the parameterized Constructor of class and pass the UserManager
        /// </summary>
        /// <param name="userManager"></param>
        public RepositoryLabel(ContextData contextData, IConfiguration configuration)
        {
            _configuration = configuration;
            _contextData = contextData;

        }

        public async Task<bool> Add(IList<string> label, int noteId, string userId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
              

                foreach (string labelModel in label)
                {
                    SqlCommand sqlCommand = new SqlCommand("InsertLabel", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@NoteId", noteId);
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    sqlCommand.Parameters.AddWithValue("@Label", labelModel);
                    sqlConnection.Open();
                    await sqlCommand.ExecuteNonQueryAsync();
                    sqlConnection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<string> DeleteLabel(int id, string UserId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);


               
                    SqlCommand sqlCommand = new SqlCommand("DeleteLabel", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                  sqlCommand.Parameters.AddWithValue("@UserId", UserId);

                ////linq for delete notes...it storing the information in delete variable for perticular id
                await sqlCommand.ExecuteNonQueryAsync();
                    sqlConnection.Close();

                return "Deleted";

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IList<LabelModel> GetLabel(string id)
        {
            try
            {

                IList<LabelModel> notesModel = new List<LabelModel>();
                SqlConnection sqlConn = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
                SqlCommand sqlComma = new SqlCommand("GetAllLabel", sqlConn);
                sqlComma.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();
                sqlComma.Parameters.AddWithValue("@UserId", id);
                SqlDataReader reader = sqlComma.ExecuteReader();
                
                while (reader.Read())
                {
                    ////userList.Id = Convert.ToInt32(sdreader["Id"]);
                    LabelModel userList = new LabelModel();
                    userList.Id = Convert.ToInt32(reader["Id"]);
                    userList.UserId = reader["UserId"].ToString();
                    userList.Label = reader["Label"].ToString();
                    userList.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                    userList.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"].ToString());
                    notesModel.Add(userList);
                }
                return notesModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> UpdateLabel(string model, int id)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
                SqlCommand sqlCommand = new SqlCommand("UpdateLabel", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.Parameters.AddWithValue("@Label", model);             
                sqlConnection.Open();
                var respone = await sqlCommand.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
