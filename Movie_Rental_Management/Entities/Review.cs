namespace Movie_Rental_Management.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid MovieId { get; set; }
        public DateTime ReviewedDate { get; set; }
        public string Comments { get; set; }
        public string Rating { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }


    }
}
