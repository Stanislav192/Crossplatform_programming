using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lab5.Models;
using System.Security.Claims;

namespace Lab5.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(UsersLabModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return RedirectToAction("Login");
        }

        public IActionResult Login(string returnUrl = "/")
        {
            return Redirect(returnUrl);
        }

        [Authorize]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Index()
        {
            var userProfile = new ViewLabsModel
            {
                Username = User.FindFirstValue("username"),
                Email = User.FindFirstValue(ClaimTypes.Email)
            };

            return View(userProfile);
        }
    }
}
