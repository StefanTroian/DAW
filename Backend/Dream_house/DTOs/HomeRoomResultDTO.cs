using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dream_house.Models;
using Dream_house.Models.Base;

namespace Dream_house.DTOs
{
    public class HomeRoomResultDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid HomeId { get; set; }
        public List<Room> Rooms { get; set; }
    }
}