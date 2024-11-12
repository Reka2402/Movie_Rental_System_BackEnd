namespace Movie_Rental_Management.Entities
{
    public class Notification
    {
       public int Id { get; set; }
       public int RecieverId  { get; set; }
       public string Title { get; set; }
       public string Message { get; set; }
       public string Type { get; set; }
       public DateOnly Date {  get; set; }
      
       public User user {  get; set; } 
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
