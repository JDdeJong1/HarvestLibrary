using HarvestLibrary.Model;

namespace HarvestLibrary.DTOs.Reservation
{
    public class CreateReservationRequestDTO
    {
        public int CustomerID { get; set; }
        public string BookTitle { get; set; } = string.Empty;
    }
}
