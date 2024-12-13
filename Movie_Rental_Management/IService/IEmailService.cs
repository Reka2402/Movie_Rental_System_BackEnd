namespace Movie_Rental_Management.IService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
