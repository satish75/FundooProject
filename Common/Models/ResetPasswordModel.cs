using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class ResetPasswordModel
    {
      
        public string Password
        {
            get; set;
        }

        public string token
        {
            get; set;
        }
    }
}
