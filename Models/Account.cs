using System.ComponentModel.DataAnnotations;

namespace MyHotel.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int StaffId { get; set; }
    }
}
