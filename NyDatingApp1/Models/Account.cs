using NyDatingApp1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NyDatingApp1.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Please provide a First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide a Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide a valid Email")]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide a Login")]
        [StringLength(100)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please provide a Password")]
        [StringLength(100)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Please provide a Password2")]
        //[StringLength(100)]
        //public string Password2 { get; set; } // Tilføj denne linje, hvis du vil inkludere Password2

        public DateTime CreateDate { get; set; } // Ingen StringLength her

        //public int ProfileId { get; set; }

        //public Profile Profile { get; set; }
    }
}