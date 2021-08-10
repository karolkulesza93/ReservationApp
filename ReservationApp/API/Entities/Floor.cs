using System.Collections.Generic;

namespace API.Entities
{
    public class Floor
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public virtual List<Room> Rooms { get; set; }

        public string FullInfo
        {
            get => $"{Name} ({Number})";
        }
    }
}
