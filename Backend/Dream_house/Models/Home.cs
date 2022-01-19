using System.ComponentModel.DataAnnotations;

namespace Dream_house.Controllers
{
    public class Home
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        //[Range(0,20)]
        public string Type { get; set; }
    }
}