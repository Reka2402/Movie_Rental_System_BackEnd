namespace Movie_Rental_Management.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MobileNumber { get; set; }
        public DateTime JoinDate { get; set; }
        public ICollection<Rent> Rents { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public bool IsActive { get; set; }

    }
}
