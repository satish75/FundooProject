// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesModel.cs" company="Bridgelabz">
//   Copyright © 2019 Company
// </copyright>
// <creator name="Satish Dodake"/>
// -------------------------------------------------------------------------------------------------
namespace Common.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Enum;
    public class NotesModel
    {    
      
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// user id declared as foregin key
        /// </summary>
       [ForeignKey("RegistrationModel")]
        public string UserId
        {
            get; set;
        }
        /// <summary>
        /// title
        /// </summary>
      ///  [DefaultValue("null")]
        public string Title
        {
            get; set;
        }

        [DefaultValue(null)]
        public string Description
        {
          get; set;
        }

     
        [RegularExpression("^#(?:[a-fA-F0-9]{3}){1,2}$")]
        public string Color
        {
            get; set;
        }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsArchive
        {
            get; set;
        }

        public bool IsPin
        {
            get; set;
        }
        public bool IsTrash
        {
            get; set;
        }
        //  public EnumNoteType NotesType { get; set; }
        public string Image
        {
            get; set;
        }

        public DateTime Reminder { get; set; }


    }
}
