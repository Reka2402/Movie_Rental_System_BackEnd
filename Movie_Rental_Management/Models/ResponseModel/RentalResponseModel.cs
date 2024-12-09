using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.Models.ResponseModel
{
    public class RentalResponseModel
    {
        public Guid Id { get; set; }
        public Guid userId { get; set; }
        public int initialPrice { get; set; }
        public Guid MovieId { get; set; }
        public string RequestedDate { get; set; }
        public string ApporovedDate { get; set; }
        public string RentalDate { get; set; }
        public  string ReturnDate { get; set; }
        public int RentalDays { get; set; }
        public int RentalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Isoverdue { get; set; } = false;
        public string Status { get; set; }
    }
}
