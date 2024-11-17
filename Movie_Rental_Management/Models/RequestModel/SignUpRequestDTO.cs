namespace Movie_Rental_Management.Models.RequestModel
{
    public class SignUpRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }    
        public int MobileNumber { get; set; }
        public string Password { get; set; }
      

    }
}
