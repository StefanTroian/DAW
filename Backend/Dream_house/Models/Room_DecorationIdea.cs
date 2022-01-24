using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models.Base;

namespace Dream_house.Models
{
    public class Room_DecorationIdea: BaseEntity
    {
        public Guid RoomId { get; set; }
        public Room Room { get; set; }


        public Guid DecorationIdeaId { get; set; }
        public DecorationIdea DecorationIdea { get; set; }
    }
}
