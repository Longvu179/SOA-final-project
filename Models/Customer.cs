using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotel.Models
{
    public class Customer
    {
        [Key]
        public string CustomerId { get; set; }
        public string IdCard {  get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Country { get; set; }
    }
}
