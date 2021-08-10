using System.Collections.Generic;

namespace API.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual List<Reservation> Reservations { get; set; }

        public string FullInfo
        {
            get => $"{Name} ({Description.ToLower()})";
        }
    }
}
