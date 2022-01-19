using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models.Base;

namespace Dream_house.Models
{
    public class Room : BaseEntity
    {
        public string Type { get; set; }
        public Home Home { get; set; }
        public Guid Home_id { get; set; }
        public ICollection<Room_DecorationIdea> Room_DecorationIdeas { get; set; }
    }
}
