using Movie_Rental_Management.Models.RequestModel;

namespace Movie_Rental_Management.IService
{
    public interface IUserservice
    {
        Task<string> SignUp(SignUpRequestDTO request);
    }
}
