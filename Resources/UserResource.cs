using System;

namespace Twitter.Resources
{
    public class UserResource : IResource
    {
        public int Id{ get; set; }
        public string Full_name { get; set; }
        public string User_login { get; set; }
        public DateTime Birth { get; set; }
        public DateTime Registration_date { get; set; }
        public string Photo_path { get; set; }
        public string User_Email { get; set; }
        public string Token { get; set; }
    }
}