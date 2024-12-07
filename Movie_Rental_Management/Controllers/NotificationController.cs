using Microsoft.AspNetCore.Mvc;

namespace Movie_Rental_Management.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
