using System;

namespace API.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }

        public string FullInfo
        {
            get => $"{Start:dd-MM-yyyy}-{End:dd-MM-yyyy}: {Title} ({Description})";
        }
    }
}
