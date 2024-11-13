using System.ComponentModel.DataAnnotations;

namespace Movie_Rental_Management.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsConfirmed { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
