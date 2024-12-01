namespace Movie_Rental_Management.Entities
{
    public class Rent
    {
        public Guid Id { get; set; }    
        public Guid CustomerId { get; set; }
        public int initialPrice { get; set; }
        public Guid MovieId { get; set; }
        public DateOnly RequestedDate { get; set; }
        public DateOnly ApporovedDate { get; set; }
        public  DateOnly Rentaldate { get; set; }
        public DateOnly ReturnDate { get; set; }
        public int RentalDays { get; set; }
        public int Rented { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        public RentStatus Status { get; set; }
        public enum RentStatus
        {
            Rented = 0,
            Pending = 1,
            Returned = 2,
            Overdue = 3,
        }
    }
}
