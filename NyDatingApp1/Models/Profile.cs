using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NyDatingApp1.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }


        [Required(ErrorMessage = "Please provide a Valid City Id")]
        [ForeignKey("CityId")]
        public int CityId { get; set; }


        [ForeignKey("Account")]
        public int AccountId { get; set; }


        [Required(ErrorMessage = "Please provide a User Name")]
        [StringLength(100)]
        public string UserName { get; set; } = null!;
        public string? AboutMe { get; set; } 
        [Required(ErrorMessage = "Please provide a Birth Date")]
        public DateTime BirthDate { get; set; } 
        public int Height { get; set; } 


        public City City { get; set; }
        public Account Account { get; set; }
        //public Profile SenderProfile { get; set; }
        //public Profile ReceiverProfile { get; set; }

        public virtual ICollection<Like> SentLikes { get; set; } = new List<Like>();
        public virtual ICollection<Like> ReceivedLikes { get; set; } = new List<Like>();
        //public ICollection<Like> SentLikes { get; set; }
        //public ICollection<Like> ReceivedLikes { get; set; }

        [NotMapped]
        public bool IsLiked { get; set; }

        [NotMapped]
        public bool HasReceivedLikes { get; set; }
    }
}
