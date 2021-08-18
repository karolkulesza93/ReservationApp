namespace API.Models
{
    public class RoomCreateDto
    {
        public int FloorId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
