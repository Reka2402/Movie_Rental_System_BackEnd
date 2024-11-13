namespace Movie_Rental_Management.Models.ResponseModel
{
    public class UserResponseModel
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } 
        public string Email { get; set; }
        public string Role { get; set; } 
    }
}
