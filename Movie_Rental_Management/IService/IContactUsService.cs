using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;

namespace Movie_Rental_Management.IService
{
    public interface IContactUsService
    {
        Task<ContactUsResponseDTO> SubmitContactAsync(ContactUsRequestDTO request);
    }
}
