namespace Movie_Rental_Management.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid Amonut { get; set; }
        public Guid ReferenceId { get; set; }
        public Rent Rent { get; set; }
        public enum Type
        {
            Cash = 0,
            Card = 1,
            BankTransfer = 2,
        }
 
    }
}
