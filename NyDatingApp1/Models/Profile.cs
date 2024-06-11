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
        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }


        [Required(ErrorMessage = "Please provide a User Name")]
        [StringLength(100)]
        public string UserName { get; set; } = null!;
        public string? AboutMe { get; set; }
        [Required(ErrorMessage = "Please provide a Birth Date")]
        public DateTime BirthDate { get; set; }
        [Range(50, 300)]
        public int Height { get; set; }


        public City City { get; set; }
        public Account Account { get; set; }
        public ICollection<Like> SentLikes { get; set; }
        public ICollection<Like> ReceivedLikes { get; set; }
        //public Account Account { get; set; }

        //public ICollection<Account> Accounts { get; set; } = new List<Account>();


        //[Required(ErrorMessage = "Please provide a Valid User Id")]
        //public int UserId { get; set; }

        //Navigation property for self-referencing many-to-many relationship
        //public virtual ICollection<Like> LikedByUsers { get; set; } = new List<Like>();
        //public virtual ICollection<Like> LikedUsers { get; set; } = new List<Like>();

        // Navigation property for self-referencing many-to-many relationship
        //public virtual ICollection<Message> SentByUsers { get; set; } = new List<Message>();
        //public virtual ICollection<Message> ReceivedByUsers { get; set; } = new List<Message>();
    }
}
