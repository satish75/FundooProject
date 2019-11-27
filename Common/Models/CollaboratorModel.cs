using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Models
{
    public class CollaboratorModel
    {
        [Key]
        public int Id {get;set;}
        public string CollaborateById { get; set; }
        
        [ForeignKey("RegistrationModel")]
        private string UserId { get; set; }

        public string UserID
        {
            get
            {
                return UserId;
            }
            set
            {
                UserId = value;
            }
        }

        [ForeignKey("NotesModel")]
        private int NotesId { get; set; }

        public int NotesID
        {
            get
            {
                return NotesId;
            }
            set
            {
                NotesId = value;
            }
        }
    }
}
