namespace Movie_Rental_Management.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amonut { get; set; }
        public int ReferenceId { get; set; }
        public Rent Rent { get; set; }
        public enum Type
        {
            Cash = 0,
            Card = 1,
            BankTransfer = 2,
        }
 
    }
}
