// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// ----------------------------------------------------------------------------------------------------
namespace Common.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Registration model of user hold all data fields user
    /// </summary>
    public class RegistrationModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
       
        [RegularExpression("^[a-zA-Z ]*$")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
       
        [RegularExpression("^[a-zA-Z ]*$")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
      ///  [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
      
        [DataType(DataType.EmailAddress)]
      
     ///   [RegularExpression("^[a-zA-Z0-9]{5,20}(@gmail.com|@yahoo.com)$")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
     
     ///   [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
       
      //  [StringLength(10, MinimumLength = 6)]
        public string Password { get; set; }

        public string ProfileImage { get; set; }

        public string UserType { get; set; }

        public string ServiceType { get; set; }
    }
}
