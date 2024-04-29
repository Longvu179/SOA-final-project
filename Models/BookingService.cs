using System.ComponentModel.DataAnnotations;

namespace MyHotel.Models
{
    public class BookingService
    {
        [Key]
        public int BookingServiceId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalMoney { get; set; }
        public string StaffId { get; set; }
    }
}
