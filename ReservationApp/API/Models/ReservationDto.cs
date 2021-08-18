using System;

namespace API.Models
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string RoomName { get; set; }
        public string SeatName { get; set; }
        public string UserName { get; set; }
        public string FullInfo { get; set; }
    }
}
