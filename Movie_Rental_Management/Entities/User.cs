namespace Movie_Rental_Management.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsConform { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<UserRole> Roles { get; set; }
    }
}
