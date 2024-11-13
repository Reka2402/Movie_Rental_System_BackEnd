namespace Movie_Rental_Management.Entities
{
    public class Rent
    {
        public Guid Id { get; set; }    
        public Guid CustomerId { get; set; }
        public Guid MovieId { get; set; }
        public DateOnly RequestedDate { get; set; }
        public DateOnly ApporovedDate { get; set; }
        public  DateOnly Rentaldate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        public enum Status {
            Rented = 0,
            Pending = 1,
            Returned = 2,
            Overdue = 3,
        }
    }
}
