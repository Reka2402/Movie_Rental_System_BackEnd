using System.ComponentModel.DataAnnotations;

namespace Movie_Rental_Management.Entities
{
    public class Staff
    {
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; }
        public int NIC { get; set; }
        public string Name { get; set; }
        public enum Type
        {
            Employee = 0,
            Manager = 1,
        }
    }
}
