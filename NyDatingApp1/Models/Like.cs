﻿using NyDatingApp1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NyDatingApp1.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }

        [Required(ErrorMessage = "Please provide a valid Liker Id")]
        //[ForeignKey("SenderProfile")]
        public int SenderId { get; set; }

        [Required(ErrorMessage = "Please provide a valid Likee Id")]
        //[ForeignKey("ReceiverProfile")]
        public int ReceiverId { get; set; }

        public int Status { get; set; } = 0;

        [ForeignKey("SenderId")]
        public Profile SenderProfile { get; set; }

        [ForeignKey("ReceiverId")]
        public Profile ReceiverProfile { get; set; }


    }
}
