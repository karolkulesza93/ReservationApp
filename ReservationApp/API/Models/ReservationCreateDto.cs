using System;

namespace API.Models
{
    public class ReservationCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string SeatId { get; set; }
        public string UserId { get; set; }
    }
}
