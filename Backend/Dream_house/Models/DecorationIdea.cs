using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models.Base;

namespace Dream_house.Models
{
    public class DecorationIdea : BaseEntity
    {
        public string Idea_description { get; set; }
        public ICollection<Room_DecorationIdea> Room_DecorationIdeas { get; set; }
    }
}
