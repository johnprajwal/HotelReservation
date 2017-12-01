namespace HotelReservation.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal Rate { get; set; }
        public string RoomType { get; set; }
        public int HotelId { get; set; }
    }
}