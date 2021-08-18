using System;

namespace API.Models
{
    public class ReservationUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
