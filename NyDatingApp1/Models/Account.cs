using NyDatingApp1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NyDatingApp1.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a First Name")]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a Last Name")]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a valid Email")]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a Login")]
        [StringLength(100)]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a Password")]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a Password2")]
        [StringLength(100)]
        public string Password2 { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Profile Profile { get; set; }
    }
}
