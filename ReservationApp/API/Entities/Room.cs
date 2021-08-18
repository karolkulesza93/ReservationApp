using System.Collections.Generic;
using API.Models;

namespace API.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FloorId { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual List<Seat> Seats { get; set; }

        public string FullInfo
        {
            get => $"{Number}. {Name}";
        }

        public void UpdateRoom(RoomUpdateDto dto)
        {
            Number = dto.Number;
            Name = dto.Name;
            Description = dto.Description;
        }
    }
}
