using System.ComponentModel.DataAnnotations;

namespace MyHotel.Models
{
    public class TempRoom
    {
        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool IsActive { get; set; }
        public double Price { get; set; }
    }
}