namespace MyHotel.Models.ViewModel
{
    public class RoomViewModel
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? DBR_Id { get; set; }
        public bool IsBooking { get; set; }
        public string? CustomerName { get; set; }
        public int? Days { get; set; }
    }
}
