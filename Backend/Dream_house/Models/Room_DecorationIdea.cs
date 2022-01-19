using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_house.Models
{
    public class Room_DecorationIdea
    {
        public Guid RoomId { get; set; }
        public Room Room { get; set; }


        public Guid DecorationIdeaId { get; set; }
        public DecorationIdea DecorationIdea { get; set; }
    }
}
