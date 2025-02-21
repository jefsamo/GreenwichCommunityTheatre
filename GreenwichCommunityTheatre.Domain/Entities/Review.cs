﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Review : BaseEntity
    {
        public required int Rating { get; set; }
        public required string PlayId { get; set; }
        public required Guid UserId { get; set; }
        public required string Comment { get; set; }

        [ForeignKey("PlayId")]
        public Play? Play { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
