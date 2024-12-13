namespace Movie_Rental_Management.Entities
{
    public class Reservation
    {
        public Guid  Id { get; set; }
        public Guid UserId { get; set; }
        public Guid  MovieId { get; set; }
        public DateTime ReservedDate { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }

    }
}
