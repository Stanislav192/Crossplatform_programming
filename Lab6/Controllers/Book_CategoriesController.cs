using Microsoft.AspNetCore.Mvc;

namespace Lab6.Controllers
{
    public class Book_CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
