﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBussinessLabel.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// --------------------------------------------------------------------------------------------------
namespace BussinessLayer.Interface
{
    using Common.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    public interface IBussinessLabel
    {
        /// <summary>
        /// Adds the specified label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        Task<bool> Add(IList<string> label, int noteId, string userId);

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> UpdateLabel(int id,string model);

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IList<LabelModel> GetLabel(string id);

        /// <summary>
        /// Deletes the label.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> DeleteLabel(int id); 
        Task<LabelModel> AddLabel(string label, string UserId); 

    }
}
