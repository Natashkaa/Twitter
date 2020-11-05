using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Domain.Models
{
    public class Tweet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Tweet_description { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Creation_date { get; set; }
        
        public int? UserId { get; set; }
        public virtual User user { get; set; }
    }
}