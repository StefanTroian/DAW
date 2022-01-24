using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_house.Models;

namespace Dream_house.DTOs
{
    public class HomeByTypeDTO
    {
        public string Type { get; set; }
        public List<Home> Home { get; set; }
    }
}
