namespace Movie_Rental_Management.Entities
{
    public class Rent
    {
        public Guid Id { get; set; }    
        public Guid userId { get; set; }
       public int initialPrice { get; set; }
        public Guid MovieId { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime ApporovedDate { get; set; }
        public  DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RentalDays { get; set; }
        public int RentalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public User user { get; set; }
        public Movie Movie { get; set; }
        public bool Isoverdue { get; set; } = false;
        public RentStatus Status { get; set; } 
      }
        public enum RentStatus
        {
            Rented = 1,
            Pending = 2,
            Approved = 3,
            Returned = 4,
            Overdue = 5,
        }
    }



