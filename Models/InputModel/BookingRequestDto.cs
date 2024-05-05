namespace MyHotel.Models.InputModel
{
    public class BookingRequestDto
    {
        public int StaffId { get; set; }
        public string IdCard { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }

}
