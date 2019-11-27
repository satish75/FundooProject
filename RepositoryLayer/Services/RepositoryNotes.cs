﻿using Common;
using Common.Enum;
using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

namespace RepositoryLayer.Services
{
    public class RepositoryNotes : IRepositoryNotes
    {
        /// </summary>
        private readonly ContextData _contextData;

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Create the parameterized Constructor of class and pass the UserManager
        /// </summary>
        /// <param name="userManager"></param>
        public RepositoryNotes(ContextData contextData, IConfiguration configuration)
        {
            _configuration = configuration;
            _contextData = contextData;
           
        }

        /// <summary>
        /// Creates the notes.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns></returns>
        public async Task<bool> CreateNotes(NotesModel notes)
        {
         
            //// Create the instance of ApplicationUser and store the details
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
                SqlCommand sqlCommand = new SqlCommand(StoreProcedureConstants.AddNotesStoreProcedure, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                ////  sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                sqlCommand.Parameters.AddWithValue("@UserId", notes.UserId);
                 //  sqlCommand.Parameters.AddWithValue("@Image", notes.Image);
                //sqlCommand.Parameters.AddWithValue("@IsArchive", notes.IsArchive);
                //sqlCommand.Parameters.AddWithValue("@IsPin", notes.IsPin);
               // sqlCommand.Parameters.AddWithValue("@IsTrash", notes.IsTrash);
                sqlCommand.Parameters.AddWithValue("@ModifiedDate", notes.ModifiedDate);
                sqlCommand.Parameters.AddWithValue("@CreatedDate", notes.CreatedDate);
               //  sqlCommand.Parameters.AddWithValue("@Reminder", notes.Reminder);
                sqlCommand.Parameters.AddWithValue("@Title", notes.Title);
                sqlCommand.Parameters.AddWithValue("@Description", notes.Description);
                sqlCommand.Parameters.AddWithValue("@Color", notes.Color);
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
        /// Gets the notes.
        /// </summary>
        /// <param name = "id" > The identifier.</param>
        /// <returns></returns>
        /// <exception cref = "Exception" ></ exception >
        public IList<NotesModel> GetNotes(string id)
        {

            try
            {
                IList<NotesModel> notesModel = new List<NotesModel>();
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
                SqlCommand sqlCommand = new SqlCommand("SpGetNotesById", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@UserId", id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
              
                while(reader.Read())
                {
                    ////userList.Id = Convert.ToInt32(sdreader["Id"]);
                    NotesModel userList = new NotesModel();
                    userList.Id = Convert.ToInt32(reader["Id"]);
                    userList.UserId = reader["UserId"].ToString();
                    userList.Image = reader["Image"].ToString();
                    userList.IsArchive = (bool)reader["IsArchive"];
                    userList.IsPin = Convert.ToBoolean(reader["IsPin"].ToString());
                    userList.IsTrash = Convert.ToBoolean(reader["IsTrash"].ToString());
                    userList.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"].ToString());
                    userList.CreatedDate = Convert.ToDateTime(reader["CreatedDate"].ToString());
                    userList.Color = reader["Color"].ToString();
                    userList.Description = reader["Description"].ToString();
                    userList.Reminder = Convert.ToDateTime(reader["Reminder"].ToString());
                    userList.Title = reader["Title"].ToString();
                    notesModel.Add(userList);
                }
                return notesModel;
            }
            catch(Exception e)
            {
                throw new Exception (e.Message.ToString());
            }
                     
        }

        /// <summary>
        /// Updateses the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> UpdateNotes(NotesModel model, int id)
          {

            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
                SqlCommand sqlCommand = new SqlCommand("SpUpdateNotes", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", model.Id);
                sqlCommand.Parameters.AddWithValue("@UserId", model.UserId);
                sqlCommand.Parameters.AddWithValue("@Description", model.Description);
                sqlCommand.Parameters.AddWithValue("@Color", model.Color);
                sqlCommand.Parameters.AddWithValue("@CreatedDate", model.CreatedDate);
                sqlCommand.Parameters.AddWithValue("@IsArchive", model.IsArchive);
                sqlCommand.Parameters.AddWithValue("@IsPin", model.IsPin);
                sqlCommand.Parameters.AddWithValue("@IsTrash", model.IsTrash);
                sqlCommand.Parameters.AddWithValue("@Image", model.Image);
                sqlCommand.Parameters.AddWithValue("@Reminder", model.Reminder);
                sqlCommand.Parameters.AddWithValue("@Title", model.Title);
                sqlCommand.Parameters.AddWithValue("@ModifiedDate", model.ModifiedDate);

                sqlConnection.Open();
                var respone = await sqlCommand.ExecuteNonQueryAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> DeleteNotes(List<int> id,string UserId)
        {
           /// var results =0;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
               

                foreach (int CurrentId in id)
                {
                    SqlCommand sqlCommand = new SqlCommand("SpDelete", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@Id", CurrentId);
                    sqlCommand.Parameters.AddWithValue("@UserId", UserId);
                    ////linq for delete notes...it storing the information in delete variable for perticular id
                     await sqlCommand.ExecuteNonQueryAsync();
                    sqlConnection.Close();

                }
               
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
             
                return 0;
        }

        /// <summary>
        /// Trashes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> Trash(int id)
        {

            SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            SqlCommand sqlCommand = new SqlCommand("SpTrashId", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            NotesModel userList = new NotesModel();
            while (reader.Read())
            {
                ////userList.Id = Convert.ToInt32(sdreader["Id"]);
             
                userList.Id = Convert.ToInt32(reader["Id"]);
                userList.IsTrash = Convert.ToBoolean(reader["IsTrash"].ToString());
            }
            sqlConnection.Close();
            /// SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            SqlCommand sqlCmd = new SqlCommand("SpTrashUpdate", sqlConnection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
          
         
            ////if notes data have records then it will update the records
            if (id != 0)
            {

                if (userList.IsTrash == false)
                {
                   // userList.IsTrash = true;
                    sqlCmd.Parameters.AddWithValue("@Id", id);
                    sqlCmd.Parameters.AddWithValue("@IsTrash", true);
                }
                else
                {
                   // userList.IsTrash = true;
                    sqlCmd.Parameters.AddWithValue("@Id", id);
                    sqlCmd.Parameters.AddWithValue("@IsTrash", false);
                }
                await sqlCmd.ExecuteNonQueryAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Trashes the restore.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> TrashRestore(int id)
        {
            if(id != 0)
            {
                await Trash(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the forever.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> DeleteForever(List<int> id, string UserId)
        {
              return await DeleteNotes(id,  UserId);
            
        }

        /// <summary>
        /// Archives the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> Archive(int id)
        {

            SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            SqlCommand sqlCommand = new SqlCommand("SpTrashId", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            NotesModel userList = new NotesModel();
            while (reader.Read())
            {
                ////userList.Id = Convert.ToInt32(sdreader["Id"]);

                userList.Id = Convert.ToInt32(reader["Id"]);
                userList.IsArchive = Convert.ToBoolean(reader["IsArchive"].ToString());
            }
            sqlConnection.Close();
            /// SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            SqlCommand sqlCmd = new SqlCommand("SpArchiveUpdate", sqlConnection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();


            ////if notes data have records then it will update the records
            if (id != 0)
            {

                if (userList.IsArchive == false)
                {
                    // userList.IsTrash = true;
                    sqlCmd.Parameters.AddWithValue("@Id", id);
                    sqlCmd.Parameters.AddWithValue("@IsArchive", true);
                }
                else
                {
                    // userList.IsTrash = true;
                    sqlCmd.Parameters.AddWithValue("@Id", id);
                    sqlCmd.Parameters.AddWithValue("@IsArchive", false);
                }
                await sqlCmd.ExecuteNonQueryAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Pins the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> Pin(int id)
        {

            SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            SqlCommand sqlCommand = new SqlCommand("SpTrashId", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            sqlCommand.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            NotesModel userList = new NotesModel();
            while (reader.Read())
            {
                ////userList.Id = Convert.ToInt32(sdreader["Id"]);

                userList.Id = Convert.ToInt32(reader["Id"]);
                userList.IsPin = Convert.ToBoolean(reader["IsPin"].ToString());
            }
            sqlConnection.Close();
            /// SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:connectionDb"]);
            SqlCommand sqlCmd = new SqlCommand("SpPinUpdate", sqlConnection);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();


            ////if notes data have records then it will update the records
            if (id != 0)
            {

                if (userList.IsPin == false)
                {
                    // userList.IsTrash = true;
                    sqlCmd.Parameters.AddWithValue("@Id", id);
                    sqlCmd.Parameters.AddWithValue("@IsPin", true);
                }
                else
                {
                    // userList.IsTrash = true;
                    sqlCmd.Parameters.AddWithValue("@Id", id);
                    sqlCmd.Parameters.AddWithValue("@IsPin", false);
                }
                await sqlCmd.ExecuteNonQueryAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Uploads the image.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="userid">The userid.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public string UploadImage(string url, string userid, int id, IFormFile file)
        {
            var image = (from notes in _contextData.notesUser
                         where notes.Id == id
                         select notes).FirstOrDefault();

            image.Image = url;
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

        public async Task<bool> Collaborate(IList<string> id,int noteId)
        {

            var resultsFromNotes = (from notes in _contextData.notesUser
                                    where notes.Id == noteId
                                    select notes).FirstOrDefault();
            try
            { 
                foreach (string UserId in id)
                {
                    var collabarate = new CollaboratorModel();
                    collabarate.UserID = UserId;
                    collabarate.NotesID = noteId;
                    collabarate.CollaborateById = resultsFromNotes.UserId;
                    _contextData.CollaborateUser.Add(collabarate);
                    var resultsOfOpearation = await _contextData.SaveChangesAsync();
                }
                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public  IList<NotesModel> Search(string word)
        {
            IList<NotesModel> listResults = new List<NotesModel>();
            try
            {

                var resultsFromLabel = (from lable in _contextData.labelUser
                                        where lable.Label == word
                                        select lable);
             ///  this loop used to serach into the label table 
                if (resultsFromLabel != null)
                {
                  foreach (LabelModel model in resultsFromLabel)
                    {
                        var resultLabel = (from note in _contextData.notesUser
                                   where note.UserId == model.UserId
                                   select note);

                        ///  take one by one record
                        foreach (NotesModel modelNote in resultLabel)
                        {
                            if(listResults.Contains(modelNote))
                            {
                                break;
                            }
                            else
                            {
                                listResults.Add(modelNote);
                            }
                           
                        }     
                    }                   
                }
               
                /// this code for take 10 record from database at a time if search is not found the it will 
                /// take next 10 record from database table
                    NotesModel notesModel1 = null;
                    int x=0;

                ///this label is used to jump if the record is not found in first ten record then it jump on
                ///this label
                  labelToNextRecord:                
                    var resultsFromNotes = (from note in _contextData.notesUser
                                            where note.Id > 0 + x && note.Id < 10 + x
                                            select note);

                    var lastItem = (from note in _contextData.notesUser
                                    select note).Last();

                    foreach (NotesModel notesModel in resultsFromNotes)
                    {
                        notesModel1 = notesModel;
                        if (notesModel.Title.Equals(word) || notesModel.Description.Contains(word) || notesModel.Color.Equals(word))
                        {                        
                            listResults.Add(notesModel1);       
                        }                                             
                    }

                    if (notesModel1 == lastItem)
                    {
                        return listResults;
                      
                    }
                    else
                    {
                        x = x + 5;
                        goto labelToNextRecord;
                    }                         
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }
    }
}

