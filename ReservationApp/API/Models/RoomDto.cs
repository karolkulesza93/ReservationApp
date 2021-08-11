﻿using System.Collections.Generic;

namespace API.Models
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FloorId { get; set; }
        public List<SeatDto> Seats { get; set; }
        public string FullInfo { get; set; }
    }
}
