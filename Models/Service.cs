using System.ComponentModel.DataAnnotations;

namespace MyHotel.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
