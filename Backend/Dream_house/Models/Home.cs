using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models.Base;

namespace Dream_house.Models
{
    public class Home: BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; } // Apartment. House, Vila, Duplex 
        public ICollection<Room> Rooms { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
