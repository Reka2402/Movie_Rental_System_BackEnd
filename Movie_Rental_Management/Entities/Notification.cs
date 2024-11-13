namespace Movie_Rental_Management.Entities
{
    public class Notification
    {
       public Guid Id { get; set; }
       public Guid RecieverId  { get; set; }
       public string Title { get; set; }
       public string Message { get; set; }
       public string Type { get; set; }
       public DateOnly Date {  get; set; }
      
       public User User {  get; set; } 
       public enum Status
        {
            Sent = 0,
            Delivered = 1,
            seen  = 2,
            Failed = 3,
            Expired = 4,
            
        }
    }
}
