using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Resources
{
    public class SaveUserResource
    {
        public string Full_name { get; set; }
        public string User_login { get; set; }
        public string User_Email { get; set; }
        [NotMapped]
        public string Birth { get; set; }
        public string User_password { get; set; }
    }
}