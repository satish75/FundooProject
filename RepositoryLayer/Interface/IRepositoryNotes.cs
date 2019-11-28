// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryNotes.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace RepositoryLayer.Interface
{
    using Common.Enum;
    using Common.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public interface IRepositoryNotes
    {
        /// <summary>
        /// Creates the notes.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        Task<bool> CreateNotes(NotesModel user);

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<NotesModel> GetNotes(string id);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> UpdateNotes(NotesModel model, int id);

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> DeleteNotes( List<int> id, string UserId);

        /// <summary>
        /// Trashes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> Trash(int id);
        Task<bool> TrashRestore(int id);
        Task<int> DeleteForever(List<int> id, string UserId);
        Task<bool> Archive(int id);
      

        Task<bool> Pin(int id);
       

        string UploadImage(string url, string userid, int id, IFormFile file);

        Task<bool> Collaborate(IList<string> id, int noteId);

        IList<NotesModel> Search(string word, string Id);
    }
}
