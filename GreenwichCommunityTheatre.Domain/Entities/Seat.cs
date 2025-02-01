using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenwichCommunityTheatre.Domain.Entities
{
    public class Seat : BaseEntity
    {
        public required string SeatNumber { get; set; }
        public required double Price { get; set; }
    }
}
