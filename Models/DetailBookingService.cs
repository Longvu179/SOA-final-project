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
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public double TotalMoney { get; set; }
    }
}
