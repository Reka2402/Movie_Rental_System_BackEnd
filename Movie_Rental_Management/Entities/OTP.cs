namespace Movie_Rental_Management.Entities
{
    public class OTP
    {
        public Guid Id { get; set; } // Primary Key

        public Guid UserId { get; set; } // Foreign Key to the User table

        public string Type { get; set; } // Type of OTP (e.g., "EmailVerification")

        public string Code { get; set; } // OTP Code

        public DateTime ExpiryDate { get; set; } // Expiration Date and Time

        public bool IsUsed { get; set; } = false; // Indicates whether the OTP has been used

        // Navigation Property
        public User User { get; set; } // Reference to the related User entity
    }

}
