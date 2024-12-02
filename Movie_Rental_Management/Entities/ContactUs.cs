using System.ComponentModel.DataAnnotations;

namespace Movie_Rental_Management.Entities
{
    public class ContactUs
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } 

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } 
        [Required]
        [MaxLength(500)]
        public string Message { get; set; } 

        public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;
    }
}
