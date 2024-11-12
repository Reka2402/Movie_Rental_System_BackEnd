namespace Movie_Rental_Management.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public User User { get; set; }


    }
}
