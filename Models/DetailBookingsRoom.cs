using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotel.Models
{
    public class DetailBookingsRoom
    {
        [Key]
        public int DBR_Id { get; set; }
        public int BookingRoomId { get; set; }
        public int RoomId { get; set; }
        public string? Name { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CreateDay { get; set; }
        public double TotalMoney { get; set; }
    }
}
