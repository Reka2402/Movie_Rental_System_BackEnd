using System.ComponentModel.DataAnnotations;

namespace Movie_Rental_Management.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role ? Role { get; set; }
        public string Nic { get; set; }
        public string Phone { get; set; }
        public ICollection<Rent> Rent { get; set; }
        public ICollection<Favouirtes> Favourites { get; set; }


    }
}
