using System.ComponentModel.DataAnnotations;

namespace MyHotel.Models
{
    public class BookingService
    {
        [Key]
        public int BookingServiceId { get; set; }
        public int DBR_Id { get; set; }
        public DateTime CreateDate { get; set; }
        public double TotalMoney { get; set; }
        public int StaffId { get; set; }
    }
}
