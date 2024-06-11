using NyDatingApp1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NyDatingApp1.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [Required(ErrorMessage = "Please provide a valid Liker Id")]
        [ForeignKey("SenderProfile")]
        public int SenderId { get; set; }

        [Required(ErrorMessage = "Please provide a valid Likee Id")]
        [ForeignKey("ReceiverProfile")]
        public int ReceiverId { get; set; }
        public int Status { get; set; } = 0;

        public Profile SenderProfile { get; set; }
        public Profile ReceiverProfile { get; set; }

        //public virtual Profile Liker { get; set; } = null!;
        //public virtual Profile Likee { get; set; } = null!;
    }
}
