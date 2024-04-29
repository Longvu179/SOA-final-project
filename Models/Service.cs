using System.ComponentModel.DataAnnotations;

namespace MyHotel.Models
{
    public class Service
    {
        [Key]
        public string ServiceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
