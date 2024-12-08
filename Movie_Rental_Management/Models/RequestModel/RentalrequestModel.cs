using Movie_Rental_Management.Entities;

namespace Movie_Rental_Management.Models.RequestModel
{
    public class RentalrequestModel
    {
       
        public Guid userId { get; set; }

        public Guid MovieId { get; set; }








        public DateTime RequestedDate { get; set; }
        public DateTime ApporovedDate { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RentalDays { get; set; }

        public decimal TotalAmount { get; set; }

  
        public bool Isoverdue { get; set; } = false;
        public RentStatus Status { get; set; } = RentStatus.Pending;
    }
}
