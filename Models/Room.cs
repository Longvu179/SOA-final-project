using System.ComponentModel.DataAnnotations;

namespace MyHotel.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public double Price { get; set;}
    }
}
