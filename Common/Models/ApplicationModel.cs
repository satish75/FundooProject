// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// ----------------------------------------------------------------------------------------------------
namespace Common.Models
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// this is Application Model class which consist credential parameter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser" />
    public class ApplicationModel : IdentityUser
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        public string ProfileImage { get; set; }

        public string UserType { get; set; }

        public string ServiceType { get; set; }
    }
}
