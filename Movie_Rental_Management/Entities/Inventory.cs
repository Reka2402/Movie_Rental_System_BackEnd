namespace Movie_Rental_Management.Entities
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public int Totalcopies { get; set; }
        public int Availablecopies { get; set; }
        public DateOnly LastRestocked { get; set; }
        public Movie Movie  { get; set; }


    }
}
