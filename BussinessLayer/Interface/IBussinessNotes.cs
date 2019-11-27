﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBussinessNotes.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace BussinessLayer.Interface
{
    using Common.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBussinessNotes
    {
       Task<bool> CreateNotes(NotesModel user);
       Task<bool> UpdateNotes(NotesModel model, int id);
       IList<NotesModel> GetNotes(string id);
        Task<int> DeleteNotes(List<int> id, string UserId);

        /// <summary>
        /// Trashes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> Trash(int id);

        /// <summary>
        /// Trashes the restore.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> TrashRestore(int id);

        /// <summary>
        /// Deletes the forever.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteForever(List<int> id, string UserId);

        Task<bool> Archive(int id);
        

        Task<bool> Pin(int id);
       
        string UploadImage(string userid, int id, IFormFile file);

        Task<bool> Collaborate(IList<string> id, int noteId);

       IList<NotesModel> Search(string word);
    }
}
