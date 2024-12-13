namespace Movie_Rental_Management.Models.ResponseModel
{
    public class ReservationResponseModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public DateTime ReservedDate { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
