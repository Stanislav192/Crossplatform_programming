using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
