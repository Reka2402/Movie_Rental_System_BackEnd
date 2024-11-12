namespace Movie_Rental_Management.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int NIC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobileNumber { get; set; }
        public DateOnly JoinDate { get; set; }
        public ICollection<Rent> Rents { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Review> Reviews { get; set; }

 

    }
}
