using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotel.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double Moneys { get; set; }
        public string Notes { get; set; }
        public string Payments { get; set; }
        public string CustomerId { get; set; }
        public string StaffId { get; set; }
    }
}
