using System.Collections.Generic;

namespace API.Models
{
    public class SeatDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
        public List<ReservationDto> Reservations { get; set; }
        public string FullInfo { get; set; }
    }
}
