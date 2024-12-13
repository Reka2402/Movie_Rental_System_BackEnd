namespace Movie_Rental_Management.Models.RequestModel
{
    public class ReservationRequestModel
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public DateTime ReservedDate { get; set; }
    }
}
