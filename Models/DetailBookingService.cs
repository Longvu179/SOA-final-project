using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotel.Models
{
    public class DetailBookingService
    {
        [Key]
        public int DBS_Id { get; set; }
        public int BookingServiceId { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalMoney { get; set; }
    }
}
