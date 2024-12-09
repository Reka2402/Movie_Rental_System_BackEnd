namespace Movie_Rental_Management.Entities
{
    public class Favouirtes
    {
            public Guid UserId { get; set; }
            public User User { get; set; }

            public Guid MovieId { get; set; }
            public Movie Movie { get; set; }
        
    }
}
