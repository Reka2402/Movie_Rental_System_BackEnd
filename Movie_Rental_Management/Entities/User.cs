﻿using System.ComponentModel.DataAnnotations;

namespace Movie_Rental_Management.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Role ? Role { get; set; }

        public Rent Rent { get; set; }


    }
}
