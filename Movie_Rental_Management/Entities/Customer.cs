using System.ComponentModel.DataAnnotations;

namespace Movie_Rental_Management.Entities
{
    public class Customer
    {
      
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
     
        public string Phone { get; set; }

     
      

    }
}
