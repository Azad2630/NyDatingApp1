using NyDatingApp1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NyDatingApp1.Models
{
    public class City
    {
        //public City()
        //{
        //    profiles = new List<Profile>();
        //}
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please provide a City Name")]
        [StringLength(100)]
        
        public string CityName { get; set; } = null!;

        public ICollection<Profile> Profiles { get; set; }
        //public List<Profile> profiles { get; set; }
    }
}
