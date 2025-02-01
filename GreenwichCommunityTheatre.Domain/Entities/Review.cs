using System.ComponentModel.DataAnnotations.Schema;

namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Review : BaseEntity
    {
        public required int Rating { get; set; }
        public required int PlayId { get; set; }
        public required string Comment { get; set; }

        [ForeignKey("PlayId")]
        public Play? Play { get; set; }
    }
}
