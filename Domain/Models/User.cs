using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Full_name { get; set; }

        [Required]
        [StringLength(50)]
        public string User_login { get; set; }

        [Required]
        [StringLength(50)]
        public string User_password { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Birth { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Registration_date { get; set; }

        [Required]
        [StringLength(50)]
        public string Photo_path { get; set; }

        [NotMapped]
        public virtual ICollection<Tweet> Tweets { get; set; }
        [NotMapped]
        public string Token;
    }
}