using System.ComponentModel.DataAnnotations;

namespace MyHotel.Models
{
    public class TempService
    {
        [Key]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
