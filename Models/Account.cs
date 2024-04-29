using System.ComponentModel.DataAnnotations;

namespace MyHotel.Models
{
    public class Account
    {
        [Key]
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string role { get; set; }
    }
}
