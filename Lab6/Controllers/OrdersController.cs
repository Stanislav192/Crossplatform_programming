using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
