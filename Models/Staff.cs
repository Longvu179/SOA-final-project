using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHotel.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string FullName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
    }
}
