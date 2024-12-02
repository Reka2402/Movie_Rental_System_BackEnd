using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;

namespace Movie_Rental_Management.Service
{
    public class ContactUsService : IContactUsService
    {

        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public async Task<ContactUsResponseDTO> SubmitContactAsync(ContactUsRequestDTO request)
        {
            var contact = new ContactUs
            {
                FullName = request.FullName,
                EmailAddress = request.EmailAddress,
                Message = request.Message
            };

            var savedContact = await _contactUsRepository.AddAsync(contact);

            return new ContactUsResponseDTO
            {
                ContactId = savedContact.ContactId,
                FullName = savedContact.FullName,
                EmailAddress = savedContact.EmailAddress,
                Message = savedContact.Message,
                SubmittedOn = savedContact.SubmittedOn
            };
        }
    }
}
