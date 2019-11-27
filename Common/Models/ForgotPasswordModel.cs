// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgotPasswordModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    public class ForgotPasswordModel
    {
       // [ForeignKey("Registration")]
        public string Email
        {
            get; set;
        }
    }
}
