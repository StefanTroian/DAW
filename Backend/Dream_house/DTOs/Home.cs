using System.ComponentModel.DataAnnotations;
using Dream_house.Models.Base;

namespace Dream_house.Controllers
{
    public class Home: BaseEntity
    {
        //[Required]
        //public int Id { get; set; }

        //[StringLength(50)]
        public string Name { get; set; }

        //[Range(0,20)]
        public string Type { get; set; }
    }
}