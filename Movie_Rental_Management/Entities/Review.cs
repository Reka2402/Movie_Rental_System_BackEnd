namespace Movie_Rental_Management.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime ReviewedDate { get; set; }
        public string Comments{ get; set; }
        public string Rating { get; set; }
        public Customer customer { get; set; }
        public Movie movie { get; set; }


    }
}
