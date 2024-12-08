namespace Movie_Rental_Management.Entities
{
    public class Notification
    {
       public Guid Id { get; set; }
       public Guid ReceiverId { get; set; }
       public string Title { get; set; }
       public string Message { get; set; }
       public string Type { get; set; }
       public DateOnly Date {  get; set; }
      public Status ViewStatus { get; set; }
       public User User {  get; set; } 
       public enum Status
        {
            Unread = 1,
            Sent = 2,
            Delivered = 3,
            seen  = 4,
            Failed = 5,
            Expired = 6,
            
        }
    }
}
