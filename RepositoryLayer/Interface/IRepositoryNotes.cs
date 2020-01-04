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
        Task<bool> CreateNotes(NotesModel user,string id);

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<NotesModel> GetNotes(string UserId);

        /// <summary>
        /// Updates the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> UpdateNotes(NotesModel model, int noteId);

        /// <summary>
        /// Deletes the notes.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> DeleteNotes( List<int> id, string UserId);

        /// <summary>
        /// Trashes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> Trash(int id, string userId);
        Task<bool> TrashRestore(int id);
        Task<bool> DeleteForever(List<int> id, string UserId);
        Task<bool> Archive(int id, string userId);
      

        Task<bool> Pin(int id);
       

        string UploadImage(string url, string userid, int id, IFormFile file);

        Task<bool> Collaborate(IList<string> id, int noteId, string userId);

        IList<NotesModel> Search(string word, string Id);
        IList<NotesModel> GetAllTrash(string UserId);
        
         IList<NotesModel> GetAllArchive(string UserId);
        bool ColorService(ColorModel data);
    }
}
