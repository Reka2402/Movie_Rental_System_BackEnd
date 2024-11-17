﻿using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.Models.RequestModel
{
    public class UserRequestDTO
    {
        public string FullName { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public UserRole Role { get; set; }
    }
}