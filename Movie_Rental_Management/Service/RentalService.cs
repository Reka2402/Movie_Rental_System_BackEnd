using Movie_Rental_Management.Entities;
using Movie_Rental_Management.IRepository;
using Movie_Rental_Management.IService;
using Movie_Rental_Management.Models.RequestModel;
using Movie_Rental_Management.Models.ResponseModel;
using Movie_Rental_Management.Repository;
using System.Threading.Tasks;

namespace Movie_Rental_Management.Service
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IEmailService _emailService;
        private readonly IUserRepository _userRepository;


        public RentalService(IRentalRepository rentRepository, IMovieRepository movieRepository, IEmailService emailService, IUserRepository userRepository)
        {
            _rentRepository = rentRepository;
            _movieRepository = movieRepository;
            _emailService = emailService;
            _userRepository = userRepository;

        }

        public async Task<RentalResponseModel> AddRental(RentalrequestModel rentalrequestModel)
        {
            var movie = await _movieRepository.GetDvdByIdAsync(rentalrequestModel.MovieId);

            var rental = new Rent
            {
                Id = Guid.NewGuid(),
                userId = rentalrequestModel.userId,
                initialPrice = movie.Price,
                MovieId = rentalrequestModel.MovieId,
                RequestedDate = DateTime.UtcNow,
                ApporovedDate = rentalrequestModel.ApporovedDate,
                RentalDate = rentalrequestModel.RentalDate,
                ReturnDate = rentalrequestModel.ReturnDate,
                RentalDays = (rentalrequestModel.ReturnDate - rentalrequestModel.RentalDate).Days,
                TotalAmount = rentalrequestModel.TotalAmount,
                RentalQuantity = rentalrequestModel.RentalQuantity,
                Isoverdue = rentalrequestModel.Isoverdue,
                Status = rentalrequestModel.Status
            };

            var data = await _rentRepository.AddRental(rental);

            // Email notification logic
            var user = await _userRepository.GetUserById(rentalrequestModel.userId); // Assume a repository to get user details
            var emailBody = $@"
            Dear {user.Name},
                 Your rental request for the movie '{movie.MovieName}' has been successfully processed.
                    Details:
                    - Rental Date: {rental.RentalDate:yyyy-MM-dd}
                    - Return Date: {rental.ReturnDate:yyyy-MM-dd}
                      - Total Amount: {rental.TotalAmount:C}
                     Thank you for using our service!";

            try
            {
                await _emailService.SendEmailAsync(user.Email, "Rental Confirmation", emailBody);
            }
            catch (Exception ex)
            {
                // Log the email failure but proceed with the response
                Console.WriteLine($"Failed to send email notification: {ex.Message}");
            }

            var response = new RentalResponseModel
            {
                Id = data.Id,
                userId = data.userId,
                initialPrice = data.initialPrice,
                MovieId = data.MovieId,
                RequestedDate = data.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = data.ApporovedDate.ToString("yyyy-MM-dd"),
                RentalDate = data.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = data.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = data.RentalDays,
                TotalAmount = data.TotalAmount,
                RentalQuantity = data.RentalQuantity,
                Isoverdue = data.Isoverdue,
                Status = data.Status.ToString()
            };

            return response;
        }

       public async Task ApproedRental(Guid id)
       {
           var rental = await _rentRepository.GetById(id);
           if (rental != null)
           {
               rental.Status = RentStatus.Approved;
               rental.RentalDate = DateTime.UtcNow;
               await _rentRepository.UpdateRent(rental);
           }
           // Update rental status to Approved (Enum value)
           rental.RentalDate = DateTime.UtcNow;
           rental.Status = RentStatus.Approved;  // Correctly assign the enum value
           await _rentRepository.UpdateRent(rental);  // Call UpdateRental method to update the rental in the database
       }
       
        public async Task<List<RentalResponseModel>> GetAllRentals()
        {
            var data = await _rentRepository.GetAllRentals();

            var responce = data.Select(a => new RentalResponseModel
            {
                Id = a.Id,
                userId = a.userId,
                initialPrice = a.initialPrice,
                MovieId = a.MovieId,
                RequestedDate = a.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = a.ApporovedDate.ToString("yyyy-MM-dd"),
                RentalDate = a.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = a.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = a.RentalDays,
                TotalAmount = a.TotalAmount,
                RentalQuantity = a.RentalQuantity,
                Isoverdue = a.Isoverdue,
                Status = a.Status.ToString()

            }).ToList();
            return responce;
        }

        public async Task<RentalResponseModel> GetById(Guid Id)
        {
            var data = await _rentRepository.GetById(Id);

            var response = new RentalResponseModel
            {
                Id = data.Id,
                userId = data.userId,
                initialPrice = data.initialPrice,
                MovieId = data.MovieId,
                RequestedDate = data.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = data.ApporovedDate.ToString("yyyy-MM-dd"),
                RentalDate = data.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = data.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = data.RentalDays,
                TotalAmount = data.TotalAmount,
                RentalQuantity = data.RentalQuantity,
                Isoverdue = data.Isoverdue,
                Status = data.Status.ToString()
            };
            return response;
        }

        public async Task<RentalResponseModel> GetByUserID(Guid UserId)
        {
            var data = await _rentRepository.GetByUserID(UserId);

            var response = new RentalResponseModel
            {
                Id = data.Id,
                userId = data.userId,
                initialPrice = data.initialPrice,
                MovieId = data.MovieId,
                RequestedDate = data.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = data.ApporovedDate.ToString("yyyy-MM-dd"),
                RentalDate = data.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = data.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = data.RentalDays,
                RentalQuantity = data.RentalQuantity,
                TotalAmount = data.TotalAmount,
                Isoverdue = data.Isoverdue,
                Status = data.Status.ToString()
            };
            return response;
        }

        public async Task<RentalResponseModel> UpdateRent(Guid Id, RentalrequestModel rentalrequestModel)
        {
            var rental = await _rentRepository.GetById(Id);
            if (rental == null) return null;

            rental.ApporovedDate = DateTime.Now;
            rental.Status = RentStatus.Approved;

            var data = await _rentRepository.UpdateRent(rental);

            var response = new RentalResponseModel
            {
                Id = data.Id,
                userId = data.userId,
                initialPrice = data.initialPrice,
                MovieId = data.MovieId,
                RequestedDate = data.RequestedDate.ToString("yyyy-MM-dd"),
                ApporovedDate = data.ApporovedDate.ToString("yyyy-MM-dd"),
                RentalDate = data.RentalDate.ToString("yyyy-MM-dd"),
                ReturnDate = data.ReturnDate.ToString("yyyy-MM-dd"),
                RentalDays = data.RentalDays,
                RentalQuantity = data.RentalQuantity,
                TotalAmount = data.TotalAmount,
                Isoverdue = data.Isoverdue,
                Status = data.Status.ToString()
            };
            return response;

        }








        //public async Task<IEnumerable<Rental>> GetAllRentals()
        //{
        //    return await _rentalRepository.GetAllRentals();
        //}

        //public async Task<Rental> GetRentalById(Guid id)
        //{
        //    return await _rentalRepository.GetRentalById(id);
        //}

        //public async Task ApproveRental(Guid id)
        //{
        //    var rental = await _rentalRepository.GetRentalById(id);
        //    if (rental != null)
        //    {
        //        // Add notification to customer
        //        var notification = new Notification
        //        {
        //            ReceiverId = rental.CustomerId,
        //            Title = "Rental Approved",
        //            Message = $"Your rental for {rental.DVD.Title} has been approved.",
        //            ViewStatus = "Unread",
        //            Type = "Info",
        //            Date = DateTime.UtcNow
        //        };


        //        await _notificationRepository.AddNotification(notification);

        //        var customerNotification = await _notificationRepository.GetNotificationById(notification.Id);
        //        if (customerNotification != null)
        //        {
        //            customerNotification.ViewStatus = "Read";
        //            await _notificationRepository.UpdateNotification(customerNotification);
        //        }


        //        // Decrease the available copies in the inventory
        //        await _inventoryRepository.UpdateInventory(rental.DvdId, -1);

        //        // Send WhatsApp notification
        //        var customerPhoneNumber = rental.Customer.PhoneNumber; // Replace with actual property for customer's phone number
        //        if (!string.IsNullOrEmpty(customerPhoneNumber))
        //        {
        //            var message = $"Your rental for '{rental.DVD.Title}' has been approved. Enjoy your movie!";
        //            await _whatsAppServices.SendWhatsAppNotification(customerPhoneNumber, message);
        //        }
        //    }
        //}

        //public async Task CollectRental(Guid id)
        //{
        //    var rental = await _rentalRepository.GetRentalById(id);
        //    if (rental != null)
        //    {
        //        rental.Status = RentalStatus.Collected;
        //        rental.CollectedDate = DateTime.UtcNow;
        //        await _rentalRepository.UpdateRental(rental);

        //        await _notificationRepository.AddNotification(new Notification
        //        {
        //            ReceiverId = rental.CustomerId,
        //            Title = "Rental Collected",
        //            Message = $"Your rental for {rental.DVD.Title} has been collected.",
        //            ViewStatus = "Unread",
        //            Type = "Info",
        //            Date = DateTime.UtcNow
        //        });
        //    }
        //}
        //public async Task RequestRental(CreateRentalDto createRentalDto)
        //{
        //    // Fetch the customer to validate
        //    var customer = await _customerRepository.GetCustomerById(createRentalDto.CustomerId);
        //    if (customer == null)
        //    {
        //        throw new KeyNotFoundException($"Customer with ID '{createRentalDto.CustomerId}' not found.");
        //    }

        //    // Fetch the DVD by ID to include in the rental object
        //    var dvd = await _managerRepository.GetDvdById(createRentalDto.DvdId);
        //    if (dvd == null)
        //    {
        //        throw new KeyNotFoundException($"DVD with ID '{createRentalDto.DvdId}' not found.");
        //    }

        //    // Proceed with rental creation
        //    var rental = new Rental
        //    {
        //        Id = Guid.NewGuid(),
        //        DvdId = createRentalDto.DvdId,
        //        CustomerId = createRentalDto.CustomerId,
        //        RentalDays = createRentalDto.RentalDays,
        //        Status = RentalStatus.Request,
        //        RequestDate = DateTime.UtcNow,
        //        DVD = dvd // Make sure the DVD is assigned to the rental
        //    };

        //    // Decrease available copies of the DVD
        //    await _inventoryRepository.UpdateInventory(createRentalDto.DvdId, -createRentalDto.CopySofDvd);

        //    // Save rental to repository
        //    await _rentalRepository.CreateRental(rental);

        //    // Add notification for the customer
        //    await _notificationRepository.AddNotification(new Notification
        //    {
        //        ReceiverId = rental.CustomerId,
        //        Title = "Rental Requested",
        //        Message = $"You have requested to rent {rental.DVD.Title}.",
        //        ViewStatus = "Unread",
        //        Type = "Info",
        //        Date = DateTime.UtcNow
        //    });
        //}






        //public async Task ReturnRental(Guid id)
        //{
        //    var rental = await _rentalRepository.GetRentalById(id);
        //    if (rental != null)
        //    {
        //        rental.Status = RentalStatus.Returned;
        //        rental.ReturnDate = DateTime.UtcNow;
        //        await _rentalRepository.UpdateRental(rental);

        //        // Calculate payment for the rental
        //        var payment = await _paymentService.ProcessPayment(rental);

        //        await _notificationRepository.AddNotification(new Notification
        //        {
        //            ReceiverId = rental.CustomerId,
        //            Title = "Rental Returned",
        //            Message = $"Your rental for {rental.DVD.Title} has been returned. Total payment: {payment.Amount}.",
        //            ViewStatus = "Unread",
        //            Type = "Info",
        //            Date = DateTime.UtcNow
        //        });

        //        // Update inventory to add back available copies
        //        await _inventoryRepository.UpdateInventory(rental.DvdId, 1);
        //    }
        //}

        //public async Task RejectRental(Guid id)
        //{
        //    var rental = await _rentalRepository.GetRentalById(id);
        //    if (rental != null)
        //    {
        //        rental.Status = RentalStatus.Rejected;
        //        await _rentalRepository.UpdateRental(rental);


        //        // Add notification to customer
        //        var notification = new Notification
        //        {
        //            ReceiverId = rental.CustomerId,
        //            Title = "Rental Rejected",
        //            Message = $"Your rental for {rental.DVD.Title} has been rejected.",
        //            ViewStatus = "Unread",
        //            Type = "Warning",
        //            Date = DateTime.UtcNow
        //        };

        //        await _notificationRepository.AddNotification(notification);


        //        var customerNotification = await _notificationRepository.GetNotificationById(notification.Id);
        //        if (customerNotification != null)
        //        {
        //            customerNotification.ViewStatus = "Read";  // Change to "Read"
        //            await _notificationRepository.UpdateNotification(customerNotification);
        //        }
        //    }
        //}


        //public async Task<List<Rental>> GetRentalsByCustomerId(Guid customerId)
        //{
        //    return (await _rentalRepository.GetRentalsByCustomerId(customerId)).ToList();
        //}


    }
}
