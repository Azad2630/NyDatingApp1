using NyDatingApp1.Models;
using System.ComponentModel.DataAnnotations;

namespace NyDatingApp1.Models
{
    public class City
    {
        public City()
        {
            UserProfile = new List<Profile>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a City Name")]
        [StringLength(10)]
        public string CityName { get; set; } = null!;

        public List<Profile> UserProfile { get; set; }
    }
}
