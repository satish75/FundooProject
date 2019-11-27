// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContextData.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace RepositoryLayer.Context
{
    using Common.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class ContextData :IdentityDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextData"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="T:Microsoft.EntityFrameworkCore.DbContext" />.</param>
        public ContextData(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public DbSet<ApplicationModel> User { get; set; }

        /// <summary>
        /// Gets or sets the notes user.
        /// </summary>
        /// <value>
        /// The notes user.
        /// </value>
        public DbSet<NotesModel> notesUser { get; set; }

        /// <summary>
        /// Gets or sets the label user.
        /// </summary>
        /// <value>
        /// The label user.
        /// </value>
        public DbSet<LabelModel> labelUser { get; set; }

        public DbSet<CollaboratorModel> CollaborateUser { get; set; }
    }
}
